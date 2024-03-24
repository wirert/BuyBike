import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { BicycleDetailsModel } from '../Models/bicycle-details.model';
import { ProductDetailsModel } from '../Models/product-details.model';

@Injectable({ providedIn: 'root' })
export class ProductService {
  private url: string = 'https://localhost:7129/api/';
  private http: HttpClient = inject(HttpClient);

  getProductDetails(id: string, type: string): Observable<ProductDetailsModel> {
    switch (type) {
      case 'bicycle':
        return this.http.get<BicycleDetailsModel>(`${this.url}Bicycles/${id}`);
      default:
        return this.http.get<BicycleDetailsModel>(`${this.url}Bicycles/${id}`);
    }
  }
}
