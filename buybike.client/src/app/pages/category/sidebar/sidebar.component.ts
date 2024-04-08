import { Component, Input, OnInit, inject } from '@angular/core';
import { Category } from '../../../core/models/category';
import { CategoryService } from '../../../core/services/category.service';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { Manufacturer } from '../../../core/models/manufacturer';
import { Product } from '../../../core/models/product/product';

@Component({
  selector: 'category-sidebar',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.css',
})
export class SidebarComponent implements OnInit {
  private categoryService: CategoryService = inject(CategoryService);

  @Input() selectedCategoryName: string = '';
  @Input() selectedTypeName: string = '';
  @Input() products?: Product[] = [];

  categories: Category[] | null = null;
  selectedCategoryTree: Category[] = [];

  manufacturers?: Manufacturer[];

  ngOnInit(): void {
    this.manufacturers = this.products?.reduce<Manufacturer[]>((acc, curr) => {
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

  toggle(liId: string) {
    const li = document.getElementById(liId);
    const iEl = li!.querySelector('i');
    if (li?.classList.contains('hide')) {
      li.classList.remove('hide');
      iEl?.classList.remove('fa-plus');
      iEl?.classList.add('fa-minus');
    } else {
      li?.classList.add('hide');
      iEl?.classList.remove('fa-minus');
      iEl?.classList.add('fa-plus');
    }
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
