export class ProductQueryFilter {
  makes?: string[];
  additionalFilters?: Map<number, string[]>;
  minPrice?: number;
  maxPrice?: number;
  inStock?: boolean;
}
