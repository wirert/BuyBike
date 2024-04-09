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
import { Category } from '../../../core/models/category';
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

  categories: Category[] | null = null;
  selectedCategoryTree: Category[] = [];

  manufacturers?: Manufacturer[];

  value: number = 0;
  highValue: number = 1000;
  options: Options = {
    floor: 0,
    ceil: 1500,
  };
  manualRefresh: EventEmitter<void> = new EventEmitter<void>();

  ngOnChanges(changes: SimpleChanges): void {
    this.setPriceFilter();
    this.manualRefresh.emit;
  }

  ngOnInit(): void {
    this.manufacturers = this.products!.reduce<Manufacturer[]>((acc, curr) => {
      if (acc.find((m) => m.name === curr.make.name) === undefined) {
        acc.push(curr.make);
      }
      return acc;
    }, []);

    this.categoryService.getAll().subscribe((data) => {
      this.categories = data;
      this.findSelectedCategoryTree(data, []);
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
  onUserChange(event: ChangeContext) {
    console.log('user changed');
  }
  onUserChangeEnd(event: ChangeContext) {}
  onValueChange(value: number) {}
  onHighValueChange(highValue: number) {
    console.log('user changed end');
  }

  private setPriceFilter() {
    const sorted = [...this.products!].sort((a, b) => a.price - b.price);
    this.options.floor = sorted[0].price;
    this.value = this.options.floor;
    this.options.ceil = sorted[sorted.length - 1].price;
    this.highValue = this.options.ceil;
    console.log(this.options);
    console.log(this.value);
    console.log(this.highValue);
  }

  private findSelectedCategoryTree(
    currCats: Category[],
    result: Category[],
    found: boolean = false
  ) {
    currCats.forEach((c) => {
      if (found) {
        return;
      }
      result.push(c);

      if (c.name.toLowerCase() === this.selectedCategoryName) {
        this.selectedCategoryTree = [...result];
        found = true;
        return;
      }
      this.findSelectedCategoryTree(c.subCategories, result, found);

      if (found) {
        return;
      }
      result.pop();
    });
  }
}
