import { CommonModule } from '@angular/common';
import { Component, DoCheck, OnChanges, SimpleChanges } from '@angular/core';
import { BikeTypesComponent } from '../../bike-types/bike-types.component';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule, BikeTypesComponent, RouterModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css',
})
export class HeaderComponent implements DoCheck {
  isLogged: boolean = false;
  showBikeTypes: boolean = false;

  cartItemsCount: number = 0;

  ngDoCheck(): void {
    this.checkCartItemsCount();
  }

  onBikesMouseOver() {
    this.showBikeTypes = true;
  }

  private checkCartItemsCount() {
    const cartString = sessionStorage.getItem('productsCart');

    if (cartString) {
      const count = JSON.parse(cartString).length;
      if (count !== this.cartItemsCount) {
        this.cartItemsCount = count;
      }
    }
  }
}
