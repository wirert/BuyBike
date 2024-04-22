import { CommonModule } from '@angular/common';
import {
  Component,
  ElementRef,
  OnInit,
  ViewChild,
  inject,
} from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { ProductService } from '../../core/services/product.service';
import { ProductDetails } from '../../core/models/product/product-details';
import { CartProduct } from '../../core/models/product/cart-product';
import { LoaderComponent } from '../../shared/loader/loader.component';
import { AddToCartComponent } from './add-to-cart/add-to-cart.component';

@Component({
  selector: 'product-details',
  standalone: true,
  imports: [CommonModule, FormsModule, LoaderComponent, AddToCartComponent],
  templateUrl: './product.component.html',
  styleUrl: './product.component.css',
})
export class ProductComponent implements OnInit {
  private productService: ProductService = inject(ProductService);
  private router: Router = inject(Router);

  productId: string = '';
  productName: string = '';
  productType: string = '';
  productScu: string = '';
  haveSize: boolean = false;
  product: ProductDetails | null = null;
  productImageStyleObj = {
    'background-image': '',
    'background-position': 'center',
    'background-repeat': 'no-repeat',
    'background-size': 'contain',
  };

  isLoading = true;
  showAddToCart = false;

  @ViewChild('imageDiv') imageDiv!: ElementRef;
  selectedItemIndex: string = '';

  constructor() {
    const navState = this.router.getCurrentNavigation()?.extras.state;

    if (navState) {
      this.productId = navState['id'];
      this.productType = navState['type'];
      this.productName = navState['name'];
    }
  }

  ngOnInit(): void {
    this.productService.getProductDetails(this.productId).subscribe({
      next: (data) => {
        this.product = data;

        if (data.items[0].size) {
          this.haveSize = true;
        } else {
          this.selectedItemIndex = '0';
        }
        this.productImageStyleObj[
          'background-image'
        ] = `url(${this.product?.imageUrl})`;

        this.isLoading = false;
      },
      error: (err) => {
        console.log(err);
        this.isLoading = false;
      },
    });
  }

  onMouseMoveOverPicture(event: any) {
    this.imageDiv.nativeElement.style.backgroundSize = '200%';
    this.imageDiv.nativeElement.style.backgroundPositionX =
      -event.offsetX + 'px';
    this.imageDiv.nativeElement.style.backgroundPositionY =
      -event.offsetY + 'px';
  }

  onMouseOutOfPicture() {
    this.imageDiv.nativeElement.style.backgroundSize = 'contain';
    this.imageDiv.nativeElement.style.backgroundPosition = 'center';
  }

  onBuyButtonClick() {
    this.addItemToCart();
    this.showAddToCart = true;
  }

  private addItemToCart() {
    if (!this.product || !this.selectedItemIndex) {
      return;
    }

    const cartString = sessionStorage.getItem('productsCart');
    let cart: CartProduct[] = [];

    if (cartString) {
      cart = JSON.parse(cartString);
    }

    let item = cart.find((p) => p.id === this.productId);

    if (!item) {
      item = new CartProduct(
        this.productId,
        this.productName,
        this.product.items[+this.selectedItemIndex].sku,
        this.product.imageUrl,
        this.product.price,
        this.product.discountPercent,
        this.product.make,
        this.product.items[+this.selectedItemIndex].id
      );
      cart.push(item);
    } else {
      item.quantity += 1;
    }

    sessionStorage['productsCart'] = JSON.stringify(cart);
  }
}
