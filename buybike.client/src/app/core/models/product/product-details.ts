import { Item as Item } from '../item';

export interface ProductDetails {
  name: string;
  make: string;
  makeLogoUrl: string;
  price: number;
  discountPrice: number;
  discountPercent: number | null;
  imageUrl: string;
  color: string | null;
  description: string | null;
  gender: string | null;
  category: string;
  items: Item[];
  specification: string[][];
}
