import { Routes, UrlSegment } from '@angular/router';
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
  // {
  //   matcher: (url) =>{
  //     if (url.length === 1 && url[0].path.match(/^@[\w]+$/gm)) {
  //       return {consumed: url, posParams: {username: new UrlSegment(url[0].path.slice(1), {})}};
  //     }

  //     return null;
  //   },
  //   component: CategoryComponent
  // },
  { path: '**', component: NotFoundComponent },
];

export default routes;
