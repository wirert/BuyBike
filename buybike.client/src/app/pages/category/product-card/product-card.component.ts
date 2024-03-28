import { Component, Input, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'product-card',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './product-card.component.html',
  styleUrl: './product-card.component.css',
})
export class ProductCardComponent implements OnInit {
  @Input() make: string = '';
  @Input() name: string = '';
  @Input() price: number = 0;
  @Input() imgUrl: string = '';
  @Input() category: string = '';
  @Input() id: string = '';
  @Input() itemType: string = '';

  nameForUrl: string = '';

  ngOnInit(): void {
    this.nameForUrl = this.name.split(' ').join('-').toLowerCase();
  }
}
