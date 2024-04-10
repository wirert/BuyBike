import { PropertyValues } from '../property-values';
import { Product } from './product';

export class ProductPage {
  constructor(
    public productTypeId: number,
    public totalProducts: number,
    public categoryImageUrl: string = '',
    public products: Product[],
    public attributes: PropertyValues[]
  ) {}
}
