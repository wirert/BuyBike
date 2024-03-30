export class Bicycle {
  constructor(
    public id: string,
    public name: string,
    public make: string,
    public price: number,
    public imageUrl: string,
    public tyreSize: number,
    public color: string | null,
    public category: string,
    public discountPercent: number | null
  ) {}
}
