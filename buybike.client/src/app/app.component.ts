import { HttpClientModule } from '@angular/common/http';
import { Component } from '@angular/core';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { HomeComponent } from './home/home.component';
import { RouterModule } from '@angular/router';
import { BicyclesComponent } from './categories/bicycles/bicycles.component';
import { ProductDetailsComponent } from './categories/product-details/product-details.component';

@Component({
  standalone: true,
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  imports: [
    HeaderComponent,
    FooterComponent,
    HomeComponent,
    BicyclesComponent,
    ProductDetailsComponent,
    RouterModule,
    HttpClientModule,
  ],
})
export class AppComponent {
  title = 'Buy Bike';
}
