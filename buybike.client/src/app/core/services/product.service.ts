import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { BicycleDetails } from '../models/bicycle/bicycle-details';
import { ProductDetails } from '../models/product-details';

@Injectable({ providedIn: 'root' })
export class ProductService {
  private url: string = 'https://localhost:7129/api/';
  private http: HttpClient = inject(HttpClient);

  getProductDetails(
    id: string,
    type: string
  ): Observable<ProductDetails | BicycleDetails> {
    switch (type) {
      case 'bicycle':
        return this.http.get<BicycleDetails>(`${this.url}Bicycles/${id}`);
      default:
        return this.http.get<BicycleDetails>(`${this.url}Bicycles/${id}`);
    }
  }
}
