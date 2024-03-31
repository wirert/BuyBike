import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { BikeTypesComponent } from '../../bike-types/bike-types.component';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule, BikeTypesComponent, RouterModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css',
})
export class HeaderComponent {
  isLogged: boolean = false;
  showBikeTypes: boolean = false;

  onBikesMouseOver() {
    this.showBikeTypes = true;
  }
}
