import { Component, OnDestroy, OnInit, inject } from '@angular/core';
import { ActivatedRoute, ParamMap, Params, UrlSegment } from '@angular/router';
import { CommonModule } from '@angular/common';
import { PaginatorComponent } from '../../utility/paginator/paginator.component';
import { CategoryBannerComponent } from './banner/banner.component';
import { ProductCardComponent } from './product-card/product-card.component';

import { AppConstants } from '../../core/constants/app-constants';
import { SidebarComponent } from './sidebar/sidebar.component';
import { ProductPage } from '../../core/models/products-page';
import { ProductService } from '../../core/services/product.service';
import { Subscription } from 'rxjs';
import { LoaderComponent } from '../../utility/loader/loader.component';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-category',
  standalone: true,
  imports: [
    CommonModule,
    CategoryBannerComponent,
    PaginatorComponent,
    ProductCardComponent,
    SidebarComponent,
    LoaderComponent,
  ],
  templateUrl: './category.component.html',
  styleUrl: './category.component.css',
})
export class CategoryComponent implements OnInit, OnDestroy {
  private activatedRoute: ActivatedRoute = inject(ActivatedRoute);
  private productService: ProductService = inject(ProductService);
  private paramMapSubsc: Subscription | null = null;

  productsType: string = '';
  category: string | null = '';
  productPage: ProductPage | undefined;
  currentPage: number = 1;
  itemsPerPage: number = 12;
  totalItems: number = 0;
  orderBy: string = 'Price';
  isDescending: boolean = false;

  isloading = true;
  errorMessage: string | null = null;

  ngOnInit(): void {
    this.paramMapSubsc = this.activatedRoute.paramMap.subscribe((paramMap) => {
      this.changeCategory(paramMap);
    });
  }

  ngOnDestroy(): void {
    this.paramMapSubsc!.unsubscribe();
  }

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
    this.isloading = true;
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
          this.isloading = false;
          this.productPage = data;
          console.log(data);
        },
        error: (err) => {
          this.setErrorMessage(err);
          this.isloading = false;
        },
      });
  }

  private changeCategory(paramMap: ParamMap) {
    if (paramMap.has('category')) {
      this.category = paramMap.get('category');
    }
    this.productsType = paramMap.get('type')!;
    this.currentPage = 1;

    this.fetchData();
  }

  private setErrorMessage(err: HttpErrorResponse) {
    this.errorMessage = err.message;

    setTimeout(() => {
      this.errorMessage = null;
    }, 3000);
  }
}
