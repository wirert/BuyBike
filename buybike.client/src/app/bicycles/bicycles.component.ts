import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Bicycle } from '../Models/bicycle-model';
import { BicycleService } from '../Services/bycicle.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-bicycles',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './bicycles.component.html',
  styleUrl: './bicycles.component.css',
})
export class BicyclesComponent implements OnInit {
  router: Router = inject(Router);
  activatedRoute: ActivatedRoute = inject(ActivatedRoute);
  bikeService: BicycleService = inject(BicycleService);
  type: string = '';
  bicycles: Bicycle[] = [];

  ngOnInit(): void {
    console.log(this.activatedRoute);
    const param = this.activatedRoute.snapshot.params['type'];

    if (
      param &&
      (param === 'kids' ||
        param === 'mountain' ||
        param === 'road' ||
        param === 'city' ||
        param === 'electric')
    ) {
      this.type = param;
    }

    this.bikeService.getBicycles(this.type).subscribe({
      next: (bicycles) => {
        this.bicycles = bicycles;
        console.log(bicycles);
      },
      error: (err) => console.log(err),
    });
  }
}
