export class ProductPage<T> {
  constructor(public totalProducts: number, public products: T[]) {}
}
