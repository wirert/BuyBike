import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { API_URL } from '../constants/app-constants';
import { Observable } from 'rxjs';
import { ProductType } from '../models/product-type';

@Injectable({ providedIn: 'root' })
export class CategoryService {
  private url: string = inject(API_URL);
  private http: HttpClient = inject(HttpClient);

  getAll(): Observable<ProductType[]> {
    return this.http.get<ProductType[]>(`${this.url}/ProductType`);
  }
}
