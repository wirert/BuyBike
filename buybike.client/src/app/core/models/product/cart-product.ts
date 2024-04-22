export class CartProduct {
  constructor(
    public id: string,
    public name: string,
    public scu: string,
    public imageUrl: string,
    public price: number,
    public discountPrice: number,
    public size: string | undefined,
    public discount: number | null,
    public make: string,
    public itemId: string,
    public quantity: number = 1
  ) {}

  // public get newPrice() {
  //   if (!this.discount) {
  //     return null;
  //   }

  //   return ((this.price * (100 - this.discount)) / 100).toFixed(2);
  // }
}
