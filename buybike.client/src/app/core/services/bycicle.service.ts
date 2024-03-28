import { Injectable, inject } from '@angular/core';
import { Bicycle } from '../models/bicycle/bicycle';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BicyclePage } from '../models/bicycle/paged-bicycles';

@Injectable({ providedIn: 'root' })
export class BicycleService {
  private url: string = 'https://localhost:7129/api/Bicycles/';
  private http: HttpClient = inject(HttpClient);

  getBicycles(type: string | null): Observable<Bicycle[]> {
    let params = new HttpParams();

    if (type !== null) {
      params = params.append('type', type);
    }

    return this.http.get<Bicycle[]>(this.url + 'Get', {
      params: params,
      responseType: 'json',
    });
  }

  getPagedBicycles(
    page: number,
    itemsPerPage: number,
    orderBy: string,
    desc: boolean,
    type: string | null
  ): Observable<BicyclePage> {
    let params = new HttpParams();

    params = params.append('page', page);
    params = params.append('itemsPerPage', itemsPerPage);
    params = params.append('orderBy', orderBy);
    params = params.append('desc', desc);

    if (type !== null) {
      params = params.append('type', type);
    }

    return this.http.get<BicyclePage>(this.url + 'Paged', {
      params: params,
      responseType: 'json',
    });
  }
}
