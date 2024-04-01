import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { NotFoundComponent } from './shared/not-found/not-found.component';
import { CategoryComponent } from './pages/category/category.component';
import { ProductComponent as ProductDetailsComponent } from './pages/product/product.component';

const routes: Routes = [
  { path: '', component: HomeComponent, title: 'BUY BIKE' },
  {
    path: 'велосипеди',
    component: CategoryComponent,
    title: 'Велосипеди',
  },
  {
    path: 'велосипеди/:category',
    component: CategoryComponent,
  },
  {
    path: 'p/:name',
    component: ProductDetailsComponent,
    title: 'Детайли',
  },
  { path: '**', component: NotFoundComponent },
];

export default routes;
