export class Bicycle {
  constructor(
    public id: string,
    public model: string,
    public make: string,
    public price: number,
    public imageUrl: string,
    public tyreSize: number,
    public color: string | null
  ) {}
}
