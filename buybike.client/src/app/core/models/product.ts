export interface Product {
  id: string;
  name: string;
  make: string;
  price: number;
  imageUrl: string;
  color: string | null;
  category: string;
  discountPercent: number | null;
}
