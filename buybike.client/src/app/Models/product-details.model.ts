import { ItemModel } from './item.model';

export interface ProductDetailsModel {
  Model: string;
  Make: string;
  Price: number;
  DiscountPercent: number | null;
  ImageUrl: string;
  Color: string | null;
  Description: string | null;
  Gender: string | null;
  Category: string;
  Items: ItemModel[];
  Attributes: { name: string; value: string }[];
}
