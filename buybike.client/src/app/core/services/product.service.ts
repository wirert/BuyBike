import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable, map } from 'rxjs';
import { BicycleDetails } from '../models/bicycle/bicycle-details';
import { API_URL, AppConstants } from '../constants/app-constants';
import { ProductPage } from '../models/products-page';

@Injectable({ providedIn: 'root' })
export class ProductService {
  private url: string = inject(API_URL);
  private http: HttpClient = inject(HttpClient);

  getProductDetails(id: string, type: string): Observable<any> {
    console.log(type);
    switch (type) {
      case 'велосипеди':
        return this.http.get<any>(`${this.url}/Bicycle/${id}`).pipe(
          map<any, BicycleDetails>((res, idx) => {
            res.specification = JSON.parse(res.specification);
            console.log(res.specification);
            return res;
          })
        );
      default:
        return this.http.get<any>(`${this.url}/Bicycle/${id}`).pipe(
          map<any, BicycleDetails>((res, idx) => {
            res.specification = JSON.parse(res.specification);
            return res;
          })
        );
    }
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
    let controller = AppConstants.productTypes[type];

    params = params.append('page', page);
    params = params.append('itemsPerPage', itemsPerPage);
    params = params.append('orderBy', orderBy);
    params = params.append('desc', desc);

    if (category !== null) {
      params = params.append('category', category);
    }

    if (!controller) {
      throw new Error('Грешен тип продукт.');
    }

    return this.http.get<ProductPage>(`${this.url}/${controller}`, {
      params: params,
      responseType: 'json',
    });
  }
}
