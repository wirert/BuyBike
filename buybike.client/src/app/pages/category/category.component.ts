import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router, UrlSegment } from '@angular/router';
import { CommonModule } from '@angular/common';
import { PaginatorComponent } from '../../utility/paginator/paginator.component';

import { BicycleService } from '../../core/services/bycicle.service';
import { CategoryBannerComponent } from './banner/banner.component';
import { ProductCardComponent } from './product-card/product-card.component';

import { Bicycle } from '../../core/models/bicycle/bicycle';
import { AppConstants } from '../../core/constants/app-constants';
import { SidebarComponent } from './sidebar/sidebar.component';

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
  private router: Router = inject(Router);
  private activatedRoute: ActivatedRoute = inject(ActivatedRoute);
  private bikeService: BicycleService = inject(BicycleService);

  category: string | null = '';
  bicycles: Bicycle[] = [];
  currentPage: number = 1;
  itemsPerPage: number = 12;
  totalItems: number = 0;
  orderBy: string = 'Price';
  isDescending: boolean = false;
  bikeTypes = AppConstants.bikeTypes;

  ngOnInit(): void {
    this.activatedRoute.pathFromRoot[1].url.subscribe((val) =>
      this.changeType(val)
    );
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
    this.bikeService
      .getPagedBicycles(
        this.currentPage,
        this.itemsPerPage,
        this.orderBy,
        this.isDescending,
        this.category
      )
      .subscribe({
        next: (data) => {
          this.bicycles = data.products;
          this.totalItems = data.totalProducts;

          console.log(data);
        },
        error: (err) => console.log(err),
      });
  }

  private changeType(val: UrlSegment[]) {
    if (val.length > 1) {
      const path = val[1].path.toLowerCase();
      this.category = path;
    }

    this.currentPage = 1;
    this.fetchData();
  }
}
