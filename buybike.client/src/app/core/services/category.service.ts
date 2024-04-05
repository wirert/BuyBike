import { Injectable, OnInit, inject } from '@angular/core';
import { Category } from '../models/category';
import { HttpClient } from '@angular/common/http';
import { API_URL } from '../constants/app-constants';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class CategoryService {
  private url: string = inject(API_URL);
  private http: HttpClient = inject(HttpClient);

  getAll(): Observable<Category[]> {
    return this.http.get<Category[]>(`${this.url}/Category`);
  }
}
