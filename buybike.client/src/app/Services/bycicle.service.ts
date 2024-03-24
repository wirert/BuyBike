import { Injectable, inject } from '@angular/core';
import { BicycleModel } from '../Models/bicycle.model';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BicyclePageModel } from '../Models/paged-bicycles.model';

@Injectable({ providedIn: 'root' })
export class BicycleService {
  private url: string = 'https://localhost:7129/api/Bicycles/';
  private http: HttpClient = inject(HttpClient);

  getBicycles(type: string | null): Observable<BicycleModel[]> {
    let params = new HttpParams();

    if (type !== null) {
      params = params.append('type', type);
    }

    return this.http.get<BicycleModel[]>(this.url + 'Get', {
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
  ): Observable<BicyclePageModel> {
    let params = new HttpParams();

    params = params.append('page', page);
    params = params.append('itemsPerPage', itemsPerPage);
    params = params.append('orderBy', orderBy);
    params = params.append('desc', desc);

    if (type !== null) {
      params = params.append('type', type);
    }

    return this.http.get<BicyclePageModel>(this.url + 'Paged', {
      params: params,
      responseType: 'json',
    });
  }
}
