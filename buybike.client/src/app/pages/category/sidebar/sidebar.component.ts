import {
  Component,
  EventEmitter,
  Input,
  OnChanges,
  OnInit,
  Output,
  SimpleChanges,
  inject,
} from '@angular/core';
import { CategoryService } from '../../../core/services/category.service';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { Manufacturer } from '../../../core/models/manufacturer';
import {
  ChangeContext,
  NgxSliderModule,
  Options,
} from '@angular-slider/ngx-slider';
import { ProductType } from '../../../core/models/product-type';
import { ProductPage } from '../../../core/models/product/products-page';
import { ProductFilter } from '../../../core/models/product-filter';
import { FormsModule } from '@angular/forms';
import { ProductQueryFilter } from '../../../core/models/product-query-filter';

@Component({
  selector: 'category-sidebar',
  standalone: true,
  imports: [CommonModule, RouterLink, NgxSliderModule, FormsModule],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.css',
})
export class SidebarComponent implements OnInit, OnChanges {
  private categoryService: CategoryService = inject(CategoryService);

  @Input() selectedCategoryName: string = '';
  @Input() selectedTypeName: string = '';
  @Input() productPage?: ProductPage;
  @Output() queryFilterChanged: EventEmitter<ProductQueryFilter> =
    new EventEmitter<ProductQueryFilter>();

  productTypes: ProductType[] | null = null;
  selectedType?: ProductType;
  selectedCategories: string[] = [];
  manufacturers?: Manufacturer[];

  minPrice: number = 0;
  maxPrice: number = 0;
  private filterChanged = false;
  priceBarOptions: Options = {
    floor: 0,
    ceil: 0,
    translate: (value: number): string => {
      return value + 'лв';
    },
  };
  filter: ProductFilter = new ProductFilter();
  queryFilter: ProductQueryFilter = new ProductQueryFilter();

  ngOnChanges(changes: SimpleChanges): void {
    if (this.filterChanged) {
      this.setPriceFilter();
      this.filterChanged = false;
    }
  }

  ngOnInit(): void {
    this.manufacturers = this.setManufacturersArray();

    this.categoryService.getAll().subscribe((data) => {
      this.productTypes = data;
      this.findSelectedTypeAndCategories();
      this.setProductFilterProps();
      this.setPriceFilter();
    });
  }

  toggle(elementId: string) {
    const element = document.getElementById(elementId);
    const iEl = element!.querySelector('i');
    if (element?.classList.contains('hide')) {
      element.classList.remove('hide');
      iEl?.classList.remove('fa-plus');
      iEl?.classList.add('fa-minus');
    } else {
      element?.classList.add('hide');
      iEl?.classList.remove('fa-minus');
      iEl?.classList.add('fa-plus');
    }
  }

  onFilterChanged() {
    this.filterChanged = true;
    this.setQueryFilter();
    this.queryFilterChanged.emit(this.queryFilter);
  }

  resetFilter() {
    this.setProductFilterProps();
    this.filterChanged = true;
    this.queryFilter = new ProductQueryFilter();
    this.queryFilterChanged.emit(this.queryFilter);
  }

  priceSliderEvent(changeContext: ChangeContext) {
    if (changeContext.value !== this.minPrice) {
      this.minPrice = changeContext.value;
      this.queryFilter.minPrice =
        this.minPrice === this.priceBarOptions.floor
          ? undefined
          : this.minPrice;
    }
    if (changeContext.highValue !== this.maxPrice) {
      this.maxPrice = changeContext.highValue!;
      this.queryFilter.maxPrice =
        this.maxPrice === this.priceBarOptions.ceil ? undefined : this.maxPrice;
    }

    this.queryFilterChanged.emit(this.queryFilter);
  }

  isAnyFilterSet(): boolean {
    return (
      Object.values(this.queryFilter).find((v) => v !== undefined) ||
      this.filter.outOfStock
    );
  }

  private setManufacturersArray(): Manufacturer[] {
    return this.productPage!.products.reduce<Manufacturer[]>((acc, curr) => {
      if (acc.find((m) => m.name === curr.make!.name) === undefined) {
        acc.push(curr.make!);
      }
      return acc;
    }, []);
  }

  private setPriceFilter(): void {
    const sorted = [...this.productPage!.products].sort(
      (a, b) => a.newPrice - b.newPrice
    );

    this.priceBarOptions = {
      floor: Math.floor(sorted[0].newPrice),
      ceil: Math.ceil(sorted[sorted.length - 1].newPrice),
      translate: (value: number): string => {
        return value + 'лв';
      },
    };
    this.minPrice = this.priceBarOptions.floor!;
    this.maxPrice = this.priceBarOptions.ceil!;
  }

  private setQueryFilter() {
    this.queryFilter.makes = Object.entries(this.filter.makeIds).reduce<
      string[]
    >((acc, [k, v]) => {
      if (v === true) {
        acc.push(k);
      }
      return acc;
    }, []);

    if (this.queryFilter.makes.length === 0) {
      this.queryFilter.makes = undefined;
    }

    this.queryFilter.additionalFilters = new Map<number, string[]>();

    for (const [attrId, valuesMap] of this.filter.additionalFilters) {
      let selectedValues: string[] = [];
      Object.entries(valuesMap).forEach(([attrValue, isSelected]) => {
        if (isSelected) {
          selectedValues.push(attrValue);
        }
      });
      if (selectedValues.length > 0) {
        this.queryFilter.additionalFilters.set(attrId, selectedValues);
      }
    }

    if (this.queryFilter.additionalFilters.size === 0) {
      this.queryFilter.additionalFilters = undefined;
    }

    if (this.filter.inStock && !this.filter.outOfStock) {
      this.queryFilter.inStock = true;
    } else if (!this.filter.inStock && this.filter.outOfStock) {
      this.queryFilter.inStock = false;
    } else {
      this.queryFilter.inStock = undefined;
    }

    if (this.minPrice === this.priceBarOptions.floor!) {
      this.queryFilter.minPrice = undefined;
    }

    if (this.maxPrice === this.priceBarOptions.ceil!) {
      this.queryFilter.maxPrice = undefined;
    }
  }

  private findSelectedTypeAndCategories(): void {
    this.selectedType = this.productTypes?.find(
      (t) => t.name.toLowerCase() === this.selectedTypeName.toLowerCase()
    );

    if (!this.selectedType || !this.selectedCategoryName) {
      return;
    }

    this.selectedType.categories.forEach((category) => {
      if (category.name.toLowerCase() === this.selectedCategoryName) {
        this.selectedCategories.push(category.name);
        return;
      }

      category.subCategories.forEach((subCategory) => {
        if (subCategory.name.toLowerCase() === this.selectedCategoryName) {
          this.selectedCategories.push(category.name);
          this.selectedCategories.push(subCategory.name);
          return;
        }
      });
    });
  }

  private setProductFilterProps() {
    this.productPage?.attributes.forEach((attr) => {
      const attrValuesObj: { [key: string]: boolean } = {};
      attr.values.forEach((val) => {
        attrValuesObj[val] = false;
      });
      this.filter.additionalFilters.set(attr.id, attrValuesObj);
    });

    this.manufacturers?.forEach((m) => {
      this.filter.makeIds[m.id] = false;
    });

    this.filter.inStock = false;
    this.filter.outOfStock = false;
  }
}
