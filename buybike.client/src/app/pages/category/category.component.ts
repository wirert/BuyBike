import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, UrlSegment } from '@angular/router';
import { CommonModule } from '@angular/common';
import { PaginatorComponent } from '../../utility/paginator/paginator.component';
import { CategoryBannerComponent } from './banner/banner.component';
import { ProductCardComponent } from './product-card/product-card.component';

import { AppConstants } from '../../core/constants/app-constants';
import { SidebarComponent } from './sidebar/sidebar.component';
import { ProductPage } from '../../core/models/products-page';
import { ProductService } from '../../core/services/product.service';

@Component({
  selector: 'app-category',
  standalone: true,
  imports: [
    CommonModule,
    CategoryBannerComponent,
    PaginatorComponent,
    ProductCardComponent,
    SidebarComponent,
  ],
  templateUrl: './category.component.html',
  styleUrl: './category.component.css',
})
export class CategoryComponent implements OnInit {
  private activatedRoute: ActivatedRoute = inject(ActivatedRoute);

  private productService: ProductService = inject(ProductService);

  constructor() {
    console.log('category component constructor.');
    this.activatedRoute.pathFromRoot[1].url.subscribe((val) => {
      this.changeCategory(val);
    });
  }

  productsType: string = '';
  category: string | null = '';
  productPage: ProductPage | undefined;
  currentPage: number = 1;
  itemsPerPage: number = 12;
  totalItems: number = 0;
  orderBy: string = 'Price';
  isDescending: boolean = false;
  bikeTypes = AppConstants.bikeTypes;

  ngOnInit(): void {}

  onPageChange(page: number) {
    this.currentPage = page;
    this.fetchData();
  }

  onItemsPerPageChange(items: number) {
    this.itemsPerPage = items;
    this.currentPage = 1;
    this.fetchData();
  }

  onSortingChange(sortInfo: { orderBy: string; desc: boolean }) {
    this.orderBy = sortInfo.orderBy;
    this.isDescending = sortInfo.desc;
    this.fetchData();
  }

  private fetchData(): void {
    this.productService
      .getPagedProducts(
        this.currentPage,
        this.itemsPerPage,
        this.orderBy,
        this.isDescending,
        this.category,
        this.productsType
      )
      .subscribe({
        next: (data) => {
          this.productPage = data;
          console.log(data);
        },
        error: (err) => console.log(err),
      });
  }

  private changeCategory(val: UrlSegment[]) {
    console.log(val);
    if (val.length > 1) {
      const path = val[1].path.toLowerCase();
      this.category = path;
    }
    this.productsType = val[0].path.toLowerCase();
    this.currentPage = 1;
    this.fetchData();
  }
}