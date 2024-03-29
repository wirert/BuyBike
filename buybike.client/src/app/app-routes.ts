import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { BicyclesComponent } from './categories/bicycles/bicycles.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { ProductDetailsComponent } from './categories/product-details/product-details.component';

const routes: Routes = [
  { path: '', component: HomeComponent, title: 'BUY BIKE' },
  {
    path: 'bicycles',
    component: BicyclesComponent,
    title: 'Велосипеди',
  },
  {
    path: 'bicycles/mountain',
    component: BicyclesComponent,
    title: 'Планински велосипеди',
  },
  {
    path: 'bicycles/road',
    component: BicyclesComponent,
    title: 'Шосейни велосипеди',
  },
  {
    path: 'bicycles/city',
    component: BicyclesComponent,
    title: 'Градски велосипеди',
  },
  {
    path: 'bicycles/kids',
    component: BicyclesComponent,
    title: 'Детски велосипеди',
  },
  {
    path: 'bicycles/electric',
    component: BicyclesComponent,
    title: 'Електрически велосипеди',
  },
  {
    path: 'p/:name',
    component: ProductDetailsComponent,
    title: 'Детайли',
  },
  { path: '**', component: NotFoundComponent },
];

export default routes;
