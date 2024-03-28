import { Item } from '../item';
import { ProductDetails } from '../product-details';

export class BicycleDetails implements ProductDetails {
  constructor(
    public model: string,
    public make: string,
    public makeLogoUrl: string,
    public price: number,
    public discountPercent: number | null,
    public imageUrl: string,
    public color: string | null,
    public description: string | null,
    public gender: string | null,
    public type: string,
    public items: Item[],
    public attributes: { name: string; value: string }[],
    public tyreSize: number
  ) {}
}
