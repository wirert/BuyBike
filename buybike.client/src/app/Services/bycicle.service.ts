import { Injectable, inject } from '@angular/core';
import { Bicycle } from '../Models/bicycle';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class BicycleService {
  private url: string = '';
  private http: HttpClient = inject(HttpClient);

  getBicycles(type: string): Bicycle[] {
    let bicycles: Bicycle[] = [];
    this.http.get(this.url + type);

    return bicycles;
  }
}
