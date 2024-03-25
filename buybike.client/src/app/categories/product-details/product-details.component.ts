import { CommonModule } from '@angular/common';
import {
  Component,
  ElementRef,
  Input,
  OnInit,
  ViewChild,
  inject,
} from '@angular/core';
import { ProductService } from '../../Services/product.service';
import { ProductDetailsModel } from '../../Models/product-details.model';
import { Router } from '@angular/router';
import { BicycleDetailsModel } from '../../Models/bicycle-details.model';
import { FormsModule } from '@angular/forms';
import { ItemModel } from '../../Models/item.model';

@Component({
  selector: 'product-details',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.css',
})
export class ProductDetailsComponent implements OnInit {
  private productService: ProductService = inject(ProductService);
  private router: Router = inject(Router);

  productId: string = '';
  productName: string = '';
  productType: string = '';
  productScu: string = '';
  haveSize: boolean = false;
  product: ProductDetailsModel | null = null;
  bicycle: BicycleDetailsModel | null = null;
  productImageStyleObj = {
    'background-image': '',
    'background-position': 'center',
    'background-repeat': 'no-repeat',
    'background-size': 'contain',
  };

  @ViewChild('imageDiv') imageDiv!: ElementRef;
  selectItemScu: string = '';

  constructor() {
    const navState = this.router.getCurrentNavigation()?.extras.state;

    if (navState) {
      this.productId = navState['id'];
      this.productType = navState['type'];
      this.productName = navState['name'];
    }
  }

  ngOnInit(): void {
    this.productService
      .getProductDetails(this.productId, this.productType)
      .subscribe((data) => {
        this.product = data;
        if ('tyreSize' in data) {
          this.bicycle = data;
        }
        if (data.items[0].size) {
          this.haveSize = true;
        } else {
          this.selectItemScu = data.items[0].sku;
        }
        this.productImageStyleObj[
          'background-image'
        ] = `url(${this.product?.imageUrl})`;
        console.log(this.product);
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
}
