export class ProductFilter {
  public makeIds: { [key: string]: boolean } = {};
  public inStock: boolean = false;
  public outOfStock: boolean = false;
  public minPrice?: number;
  public maxPrice?: number;
  public additionalFilters: Map<number, { [key: string]: boolean }> = new Map<
    number,
    { [key: string]: boolean }
  >();
}
