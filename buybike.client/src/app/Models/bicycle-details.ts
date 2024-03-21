import { Item } from './item';

export class BicycleDetails {
  constructor(
    public Model: string,
    public Make: string,
    public Price: number,
    public ImageUrl: string,
    public Color: string | null,
    public Description: string | null,
    public Gender: string | null,
    public Category: string,
    public TyreSize: number,
    public Items: Item[],
    public Attributes: { name: string; value: string }[]
  ) {}
}
