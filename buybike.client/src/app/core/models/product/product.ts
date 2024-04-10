import { Manufacturer } from '../manufacturer';

export class Product {
  public id: string = '';
  public name: string = '';
  public make?: Manufacturer;
  public price: number = 0;
  public imageUrl: string = '';
  public color: string | null = null;
  public category: string = '';
  public discountPercent: number | null = null;
  public isInStock: boolean = false;
  constructor(obj: Object | Product) {
    Object.assign(this, obj);
  }

  get newPrice(): number | null {
    if (!this.discountPercent) {
      return null;
    }

    return (this.price * (100 - this.discountPercent)) / 100;
  }
}
