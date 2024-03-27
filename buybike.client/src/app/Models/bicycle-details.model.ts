import { ProductDetailsModel } from './product-details.model';

export interface BicycleDetailsModel extends ProductDetailsModel {
  tyreSize: number;
}
