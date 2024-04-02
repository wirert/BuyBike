import { Product } from './product';

export class ProductPage {
  constructor(
    public totalProducts: number,
    public categoryImageUrl: string = '',
    public products: Product[]
  ) {}
}
