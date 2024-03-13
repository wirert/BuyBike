import { Injectable, inject } from '@angular/core';
import { Bicycle } from '../Models/bicycle-model';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, map } from 'rxjs';

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
}
