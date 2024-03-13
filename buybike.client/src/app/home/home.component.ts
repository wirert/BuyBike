import { Component } from '@angular/core';
import { BannerComponent } from './banner/banner.component';
import { BikeTypesComponent } from '../categories/bicycles/bike-types/bike-types.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [BannerComponent, BikeTypesComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent {}
