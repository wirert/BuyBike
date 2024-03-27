import { ItemModel } from './item.model';

export interface ProductDetailsModel {
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
  items: ItemModel[];
  attributes: { name: string; value: string }[];
}
