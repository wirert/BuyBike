import { StringIndex } from '../Contracts/map-string-index';

export class BicycleModel {
  constructor(
    public id: string,
    public model: string,
    public make: string,
    public price: number,
    public imageUrl: string,
    public tyreSize: number,
    public color: string | null,
    public type: string
  ) {}
}
