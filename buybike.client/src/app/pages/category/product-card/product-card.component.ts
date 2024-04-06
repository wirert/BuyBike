import { NgIf, NgStyle } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { Product } from '../../../core/models/product/product';

@Component({
  selector: 'product-card',
  standalone: true,
  imports: [RouterModule, NgIf, NgStyle],
  templateUrl: './product-card.component.html',
  styleUrl: './product-card.component.css',
})
export class ProductCardComponent implements OnInit {
  @Input() itemType: string = '';
  @Input() product: Product | null = null;

  nameForUrl: string = '';

  ngOnInit(): void {
    this.nameForUrl =
      this.product?.name.split(' ').join('-').toLowerCase() ?? '';
  }
}
