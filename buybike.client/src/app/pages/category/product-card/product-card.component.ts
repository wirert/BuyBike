import { NgIf, NgStyle } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'product-card',
  standalone: true,
  imports: [RouterModule, NgIf, NgStyle],
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
  @Input() discountPercent: number | null = null;

  nameForUrl: string = '';

  ngOnInit(): void {
    this.nameForUrl = this.name.split(' ').join('-').toLowerCase();
  }
}
