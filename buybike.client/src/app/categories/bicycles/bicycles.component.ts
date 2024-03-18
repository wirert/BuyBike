import { Component, DoCheck, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Bicycle } from '../../Models/bicycle-model';
import { BicycleService } from '../../Services/bycicle.service';
import { CommonModule } from '@angular/common';
import { CategoryBannerComponent } from '../category-banner/category-banner.component';
import { PaginatorComponent } from '../../utility/paginator/paginator.component';
import { ProductCardComponent } from '../card/product-card.component';
import { StringIndex } from '../../Contracts/map-string-index';

@Component({
  selector: 'app-bicycles',
  standalone: true,
  imports: [
    CommonModule,
    CategoryBannerComponent,
    PaginatorComponent,
    ProductCardComponent,
  ],
  templateUrl: './bicycles.component.html',
  styleUrl: './bicycles.component.css',
})
export class BicyclesComponent implements DoCheck {
  private router: Router = inject(Router);
  private activatedRoute: ActivatedRoute = inject(ActivatedRoute);
  private bikeService: BicycleService = inject(BicycleService);

  type: string | null = '';
  bicycles: Bicycle[] = [];
  currentPage: number = 1;
  itemsPerPage: number = 12;
  totalItems: number = 0;
  orderBy: string = 'price';
  isDescending: boolean = false;

  bikeTypes: StringIndex = {
    Mountain: 'Планински',
    Kids: 'Детски',
    Road: 'Шосеен',
    City: 'Градски',
    Electric: 'Електрически',
  };

  ngDoCheck(): void {
    if (this.typeChanged()) {
      this.currentPage = 1;
      this.fetchData();
    }
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
        this.type
      )
      .subscribe({
        next: (data) => {
          this.bicycles = data.bicycles;
          this.totalItems = data.totalBicycles;

          console.log(data);
        },
        error: (err) => console.log(err),
      });
  }

  private typeChanged(): boolean {
    let param = this.activatedRoute.snapshot.params['type'];

    if (!param) {
      param = null;
    }

    if (param === this.type) {
      return false;
    }

    if (
      !param ||
      param === 'kids' ||
      param === 'mountain' ||
      param === 'road' ||
      param === 'city' ||
      param === 'electric'
    ) {
      this.type = param;
    } else {
      this.router.navigateByUrl('bicycles');
    }

    return true;
  }
}
