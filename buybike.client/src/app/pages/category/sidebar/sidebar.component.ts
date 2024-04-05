import { Component, OnInit, inject } from '@angular/core';
import { Category } from '../../../core/models/category';
import { CategoryService } from '../../../core/services/category.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'category-sidebar',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.css',
})
export class SidebarComponent implements OnInit {
  private categoryService: CategoryService = inject(CategoryService);

  categories: Category[] | null = null;

  ngOnInit(): void {
    this.categoryService.getAll().subscribe((data) => {
      this.categories = data;
      console.log(this.categories);
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
}
