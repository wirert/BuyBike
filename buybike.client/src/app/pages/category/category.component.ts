import { Component, OnDestroy, OnInit, inject } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { CommonModule } from '@angular/common';
import { PaginatorComponent } from '../../shared/paginator/paginator.component';
import { CategoryBannerComponent } from './banner/banner.component';
import { ProductCardComponent } from './product-card/product-card.component';

import { SidebarComponent } from './sidebar/sidebar.component';
import { ProductPage } from '../../core/models/product/products-page';
import { ProductService } from '../../core/services/product.service';
import { Subscription } from 'rxjs';
import { LoaderComponent } from '../../shared/loader/loader.component';
import { HttpErrorResponse } from '@angular/common/http';
import { SnackbarComponent } from '../../shared/snackbar/snackbar.component';
import { MessageConstants } from '../../core/constants/message-constants';
import { PaginatorState } from '../../core/models/paginator-state';
import { Title } from '@angular/platform-browser';
import { ProductQueryFilter } from '../../core/models/product-query-filter';

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
    SnackbarComponent,
  ],
  templateUrl: './category.component.html',
  styleUrl: './category.component.css',
})
export class CategoryComponent implements OnInit, OnDestroy {
  private activatedRoute: ActivatedRoute = inject(ActivatedRoute);
  private productService: ProductService = inject(ProductService);
  private titleService: Title = inject(Title);
  private paramMapSubsc?: Subscription;
  private productsSubscription?: Subscription;

  productsType: string = '';
  category: string | null = '';
  productsPage: ProductPage | undefined;
  paginatorState: PaginatorState = new PaginatorState();
  filter?: ProductQueryFilter;

  isloading = true;
  errorMessage: string | null = null;

  ngOnInit(): void {
    this.paramMapSubsc = this.activatedRoute.paramMap.subscribe({
      next: (paramMap) => {
        this.changeCategory(paramMap);
      },
      error: (err) => {
        this.setErrorMessage(err);
      },
    });
  }

  ngOnDestroy(): void {
    this.paramMapSubsc!.unsubscribe();
    this.productsSubscription?.unsubscribe();
  }

  onFilterChange(filter: ProductQueryFilter) {
    this.filter = filter;
    this.fetchData();
  }

  onPaginatorStateChange(paginatorState: PaginatorState) {
    this.paginatorState = paginatorState;
    this.fetchData();
  }

  private fetchData(): void {
    this.isloading = true;
    this.productsSubscription = this.productService
      .getPagedProducts(
        this.paginatorState,
        this.category,
        this.productsType,
        this.filter
      )
      .subscribe({
        next: (data) => {
          if (data.products.length === 0) {
            this.setErrorMessage(
              new HttpErrorResponse({ error: 'Няма намерени продукти' })
            );
          }
          this.isloading = false;

          this.productsPage = data;
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
    this.paginatorState.pageNumber = 1;

    this.titleService.setTitle(`${this.category} ${this.productsType}`);

    this.fetchData();
  }

  private setErrorMessage(err: HttpErrorResponse) {
    console.log(err);
    if (err.statusText === 'OK') {
      this.errorMessage = err.error;
    } else {
      this.errorMessage = MessageConstants.UnknownErrorMessage;
    }

    setTimeout(() => {
      this.errorMessage = null;
    }, 5000);
  }
}
