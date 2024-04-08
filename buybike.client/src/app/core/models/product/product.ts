import { Manufacturer } from '../manufacturer';

export interface Product {
  id: string;
  name: string;
  make: Manufacturer;
  price: number;
  imageUrl: string;
  color: string | null;
  category: string;
  discountPercent: number | null;
}
