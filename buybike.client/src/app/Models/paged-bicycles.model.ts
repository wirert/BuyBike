import { BicycleModel } from './bicycle.model';

export class BicyclePageModel {
  constructor(public totalBicycles: number, public bicycles: BicycleModel[]) {}
}
