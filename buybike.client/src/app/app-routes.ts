import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { NotFoundComponent } from './shared/not-found/not-found.component';
import { CategoryComponent } from './pages/category/category.component';
import { ProductComponent } from './pages/product/product.component';

const routes: Routes = [
  { path: '', component: HomeComponent, title: 'BUY BIKE' },
  {
    path: 'bicycles',
    component: CategoryComponent,
    title: 'Велосипеди',
  },
  {
    path: 'bicycles/mountain',
    component: CategoryComponent,
    title: 'Планински велосипеди',
  },
  {
    path: 'bicycles/road',
    component: CategoryComponent,
    title: 'Шосейни велосипеди',
  },
  {
    path: 'bicycles/city',
    component: CategoryComponent,
    title: 'Градски велосипеди',
  },
  {
    path: 'bicycles/kids',
    component: CategoryComponent,
    title: 'Детски велосипеди',
  },
  {
    path: 'bicycles/electric',
    component: CategoryComponent,
    title: 'Електрически велосипеди',
  },
  {
    path: 'p/:name',
    component: ProductComponent,
    title: 'Детайли',
  },
  { path: '**', component: NotFoundComponent },
];

export default routes;
