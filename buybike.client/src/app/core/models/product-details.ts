import { Item as Item } from './item';

export interface ProductDetails {
  model: string;
  make: string;
  makeLogoUrl: string;
  price: number;
  discountPercent: number | null;
  imageUrl: string;
  color: string | null;
  description: string | null;
  gender: string | null;
  type: string;
  items: Item[];
  attributes: { name: string; value: string }[];
}
