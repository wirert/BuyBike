import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable, map, retry } from 'rxjs';
import { API_URL, AppConstants } from '../constants/app-constants';
import { ProductPage } from '../models/product/products-page';
import { ProductDetails } from '../models/product/product-details';
import { PaginatorState } from '../models/paginator-state';
import { Product } from '../models/product/product';

@Injectable({ providedIn: 'root' })
export class ProductService {
  private url: string = inject(API_URL);
  private http: HttpClient = inject(HttpClient);

  getProductDetails(id: string): Observable<any> {
    return this.http.get<any>(`${this.url}/Product/${id}`).pipe(
      map<any, ProductDetails>((res, idx) => {
        res.specification = JSON.parse(res.specification);
        return res;
      })
    );
  }

  getPagedProducts(
    paginatorState: PaginatorState,
    category: string | null,
    type: string
  ): Observable<any> {
    const productType = AppConstants.productTypes[type];

    if (!productType) {
      throw new Error('Грешен тип продукт.');
    }

    let params = new HttpParams();
    params = params.append('productType', productType);
    params = params.append('page', paginatorState.pageNumber);
    params = params.append('itemsPerPage', paginatorState.itemsPerPage);
    params = params.append('orderBy', paginatorState.orderBy);
    params = params.append('desc', paginatorState.desc);

    if (category !== null) {
      params = params.append('category', category);
    }

    return this.http
      .get<ProductPage>(`${this.url}/Product`, {
        params: params,
        responseType: 'json',
      })
      .pipe(
        retry(),
        map(
          (productPage) =>
            new ProductPage(
              productPage.productTypeId,
              productPage.totalProducts,
              productPage.categoryImageUrl,
              productPage.products.map((p) => new Product(p)),
              productPage.attributes
            )
        )
      );
  }
}
