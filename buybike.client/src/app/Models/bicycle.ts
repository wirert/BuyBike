export class Bicycle {
  constructor(
    public id: string,
    public type: string,
    public model: string,
    public make: string,
    public material: string,
    public price: number,
    public sizes: number[],
    public image: ImageData,
    public color: string,
    public gender?: string
  ) {}
}
