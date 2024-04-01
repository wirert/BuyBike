import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable, map } from 'rxjs';
import { BicycleDetails } from '../models/bicycle/bicycle-details';
import { ProductDetails } from '../models/product-details';
import { API_URL } from '../constants/app-constants';

@Injectable({ providedIn: 'root' })
export class ProductService {
  private url: string = inject(API_URL);
  private http: HttpClient = inject(HttpClient);

  getProductDetails(id: string, type: string): Observable<any> {
    switch (type) {
      case 'bicycle':
        return this.http.get<any>(`${this.url}Bicycle/${id}`).pipe(
          map<any, BicycleDetails>((res, idx) => {
            res.specification = JSON.parse(res.specification);
            return res;
          })
        );
      default:
        return this.http.get<BicycleDetails>(`${this.url}Bicycle/${id}`);
    }
  }
}
