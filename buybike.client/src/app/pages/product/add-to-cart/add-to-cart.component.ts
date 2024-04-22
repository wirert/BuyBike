import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'add-to-cart',
  standalone: true,
  imports: [],
  templateUrl: './add-to-cart.component.html',
  styleUrl: './add-to-cart.component.css',
})
export class AddToCartComponent {
  @Input() show = false;
  @Output() showChange = new EventEmitter<boolean>();

  @Input() productName = '';
  @Input() price: number = 0;
  @Input() imgUrl: string = '';

  close() {
    this.show = false;
    this.showChange.emit(this.show);
  }
}
