import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { BicyclesComponent } from './bicycles/bicycles.component';

const routes: Routes = [
  { path: '', component: HomeComponent, title: 'Home page' },
  {
    path: 'bicycles/:type',
    component: BicyclesComponent,
    title: 'Велосипеди',
  },
];

export default routes;
