import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable, map } from 'rxjs';
import { API_URL, AppConstants } from '../constants/app-constants';
import { ProductPage } from '../models/product/products-page';
import { ProductDetails } from '../models/product/product-details';

@Injectable({ providedIn: 'root' })
export class ProductService {
  private url: string = inject(API_URL);
  private http: HttpClient = inject(HttpClient);

  getProductDetails(id: string, type: string): Observable<any> {
    const controller = AppConstants.productTypes[type];
    return this.http.get<any>(`${this.url}/${controller}/${id}`).pipe(
      map<any, ProductDetails>((res, idx) => {
        res.specification = JSON.parse(res.specification);
        return res;
      })
    );
  }

  getPagedProducts(
    page: number,
    itemsPerPage: number,
    orderBy: string,
    desc: boolean,
    category: string | null,
    type: string
  ): Observable<any> {
    let params = new HttpParams();
    params = params.append('page', page);
    params = params.append('itemsPerPage', itemsPerPage);
    params = params.append('orderBy', orderBy);
    params = params.append('desc', desc);

    if (category !== null) {
      params = params.append('category', category);
    }

    const controller = AppConstants.productTypes[type];

    if (!controller) {
      throw new Error('Грешен тип продукт.');
    }

    return this.http.get<ProductPage>(`${this.url}/${controller}`, {
      params: params,
      responseType: 'json',
    });
  }
}
