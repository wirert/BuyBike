import { Injectable, inject } from '@angular/core';
import { Bicycle } from '../models/bicycle/bicycle';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProductPage } from '../models/products-page';

@Injectable({ providedIn: 'root' })
export class BicycleService {
  private url: string = 'https://localhost:7129/api/Bicycle';
  private http: HttpClient = inject(HttpClient);

  getBicycles(category: string | null): Observable<Bicycle[]> {
    let params = new HttpParams();

    if (category !== null) {
      params = params.append('type', category);
    }

    return this.http.get<Bicycle[]>(this.url, {
      params: params,
      responseType: 'json',
    });
  }

  getPagedBicycles(
    page: number,
    itemsPerPage: number,
    orderBy: string,
    desc: boolean,
    category: string | null
  ): Observable<ProductPage<Bicycle>> {
    let params = new HttpParams();

    params = params.append('page', page);
    params = params.append('itemsPerPage', itemsPerPage);
    params = params.append('orderBy', orderBy);
    params = params.append('desc', desc);

    if (category !== null) {
      params = params.append('category', category);
    }

    return this.http.get<ProductPage<Bicycle>>(this.url, {
      params: params,
      responseType: 'json',
    });
  }
}
