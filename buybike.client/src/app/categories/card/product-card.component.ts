import { Component, Input } from '@angular/core';

@Component({
  selector: 'product-card',
  standalone: true,
  imports: [],
  templateUrl: './product-card.component.html',
  styleUrl: './product-card.component.css',
})
export class ProductCardComponent {
  @Input() make: string = '';
  @Input() name: string = '';
  @Input() price: number = 0;
}
