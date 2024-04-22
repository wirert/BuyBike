import { Component, OnInit } from '@angular/core';
import { CartProduct } from '../../core/models/product/cart-product';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'shopping-cart',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './shopping-cart.component.html',
  styleUrl: './shopping-cart.component.css',
})
export class ShoppingCartComponent implements OnInit {
  products: CartProduct[] = [];

  ngOnInit(): void {
    const cartStr = sessionStorage.getItem('productsCart');

    if (cartStr) {
      this.products = JSON.parse(cartStr);
    }

    console.log(this.products);
  }
}
