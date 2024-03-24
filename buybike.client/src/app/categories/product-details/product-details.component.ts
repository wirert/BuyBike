import { CommonModule } from '@angular/common';
import {
  Component,
  ElementRef,
  OnInit,
  ViewChild,
  inject,
} from '@angular/core';
import { ProductService } from '../../Services/product.service';
import { ProductDetailsModel } from '../../Models/product-details.model';
import { Router } from '@angular/router';

@Component({
  selector: 'product-details',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.css',
})
export class ProductDetailsComponent implements OnInit {
  private productService: ProductService = inject(ProductService);
  private router: Router = inject(Router);

  productId: string = '';
  productType: string = '';
  product: ProductDetailsModel | null = null;

  @ViewChild('imageDiv') imageDiv!: ElementRef;

  constructor() {
    const navState = this.router.getCurrentNavigation()?.extras.state;

    if (navState) {
      this.productId = navState['id'];
      this.productType = navState['type'];
    }
  }

  ngOnInit(): void {
    this.productService
      .getProductDetails(this.productId, this.productType)
      .subscribe((data) => {
        console.log(data);
        this.product = data;
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
