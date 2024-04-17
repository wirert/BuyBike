export class ProductFilter {
  public makeIds: { [key: string]: boolean } = {};
  public inStock: boolean = false;
  public outOfStock: boolean = false;
  public additionalFilters: Map<number, { [key: string]: boolean }> = new Map<
    number,
    { [key: string]: boolean }
  >();
}
