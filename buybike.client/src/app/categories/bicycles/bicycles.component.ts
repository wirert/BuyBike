import { Component, DoCheck, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Bicycle } from '../../Models/bicycle-model';
import { BicycleService } from '../../Services/bycicle.service';
import { CommonModule } from '@angular/common';
import { CategoryBannerComponent } from '../category-banner/category-banner.component';
import { PaginatorComponent } from '../../utility/paginator/paginator.component';

@Component({
  selector: 'app-bicycles',
  standalone: true,
  imports: [CommonModule, CategoryBannerComponent, PaginatorComponent],
  templateUrl: './bicycles.component.html',
  styleUrl: './bicycles.component.scss',
})
export class BicyclesComponent implements DoCheck {
  private router: Router = inject(Router);
  private activatedRoute: ActivatedRoute = inject(ActivatedRoute);
  private bikeService: BicycleService = inject(BicycleService);

  type: string | null = '';
  bicycles: Bicycle[] = [];

  ngDoCheck(): void {
    let param = this.activatedRoute.snapshot.params['type'];

    if (!param) {
      param = null;
    }

    if (param !== this.type) {
      if (
        !param ||
        param === 'kids' ||
        param === 'mountain' ||
        param === 'road' ||
        param === 'city' ||
        param === 'electric'
      ) {
        this.type = param;

        this.bikeService.getBicycles(this.type).subscribe({
          next: (bicycles) => {
            this.bicycles = bicycles;
            console.log(bicycles);
          },
          error: (err) => console.log(err),
        });
      } else {
        this.router.navigateByUrl('bicycles');
      }
    }
  }
}
