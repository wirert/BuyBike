import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-bicycles',
  standalone: true,
  imports: [],
  templateUrl: './bicycles.component.html',
  styleUrl: './bicycles.component.css',
})
export class BicyclesComponent implements OnInit {
  router: Router = inject(Router);
  activatedRoute: ActivatedRoute = inject(ActivatedRoute);
  type: string = '';

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
  }
}
