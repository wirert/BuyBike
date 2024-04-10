import {
  Component,
  Input,
  OnChanges,
  OnInit,
  SimpleChanges,
  inject,
} from '@angular/core';
import { CategoryService } from '../../../core/services/category.service';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { Manufacturer } from '../../../core/models/manufacturer';
import { Product } from '../../../core/models/product/product';
import {
  ChangeContext,
  NgxSliderModule,
  Options,
} from '@angular-slider/ngx-slider';
import { ProductType } from '../../../core/models/product-type';

@Component({
  selector: 'category-sidebar',
  standalone: true,
  imports: [CommonModule, RouterLink, NgxSliderModule],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.css',
})
export class SidebarComponent implements OnInit, OnChanges {
  private categoryService: CategoryService = inject(CategoryService);

  @Input() selectedCategoryName: string = '';
  @Input() selectedTypeName: string = '';
  @Input() products?: Product[] = [];

  productTypes: ProductType[] | null = null;
  selectedType?: ProductType;
  selectedCategories: string[] = [];

  manufacturers?: Manufacturer[];

  value: number = 0;
  highValue: number = 1000;
  options: Options = {
    floor: 0,
    ceil: 1500,
  };

  ngOnChanges(changes: SimpleChanges): void {
    this.setPriceFilter();
  }

  ngOnInit(): void {
    this.manufacturers = this.products!.reduce<Manufacturer[]>((acc, curr) => {
      if (acc.find((m) => m.name === curr.make!.name) === undefined) {
        acc.push(curr.make!);
      }
      return acc;
    }, []);

    this.categoryService.getAll().subscribe((data) => {
      this.productTypes = data;

      this.findSelectedTypeAndCategories();
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

  onUserChangeStart(event: ChangeContext) {}
  onUserChange(event: ChangeContext) {}
  onUserChangeEnd(event: ChangeContext) {}
  onValueChange(value: number) {}
  onHighValueChange(highValue: number) {}

  private setPriceFilter(): void {
    const sorted = [...this.products!].sort((a, b) => a.newPrice - b.newPrice);
    this.options = {
      floor: Math.floor(sorted[0].newPrice),
      ceil: Math.ceil(sorted[sorted.length - 1].newPrice),
    };
    this.value = this.options.floor!;
    this.highValue = this.options.ceil!;
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
}
