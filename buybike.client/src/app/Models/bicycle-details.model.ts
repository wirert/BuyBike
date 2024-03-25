import { ProductDetailsModel } from './product-details.model';

export interface BicycleDetailsModel extends ProductDetailsModel {
  tyreSize: number;

  // constructor(
  //   model: string,
  //   make: string,
  //   price: number,
  //   discount: number | null,
  //   imageUrl: string,
  //   color: string | null,
  //   desc: string | null,
  //   gender: string | null,
  //   category: string,
  //   items: Item[],
  //   attr: { name: string; value: string }[],
  //   tyreSize: number
  // ) {
  //   super(
  //     model,
  //     make,
  //     price,
  //     discount,
  //     imageUrl,
  //     color,
  //     desc,
  //     gender,
  //     category,
  //     items,
  //     attr
  //   );
  //   this.TyreSize = tyreSize;
  // }
}
