import { Item } from '../item';
import { ProductDetails } from '../product-details';

export class BicycleDetails implements ProductDetails {
  constructor(
    public name: string,
    public make: string,
    public makeLogoUrl: string,
    public price: number,
    public discountPercent: number | null,
    public imageUrl: string,
    public color: string | null,
    public description: string | null,
    public gender: string | null,
    public category: string,
    public items: Item[],
    public specification: string[][],
    public tyreSize: number
  ) {}
}
