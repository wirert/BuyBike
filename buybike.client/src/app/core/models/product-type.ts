import { Category } from './category';
import { PropertyValues } from './property-values';

export class ProductType {
  constructor(
    public id: number,
    public name: string,
    public productProps: PropertyValues[],
    public categories: Category[]
  ) {}
}
