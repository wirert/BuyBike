import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, OnInit, inject } from '@angular/core';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { HomeComponent } from './home/home.component';
import { RouterModule } from '@angular/router';
import { BicyclesComponent } from './categories/bicycles/bicycles.component';
import { ProductDetailsComponent } from './categories/product-details/product-details.component';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

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
export class AppComponent implements OnInit {
  title = 'Buy Bike';
  private http: HttpClient = inject(HttpClient);

  ngOnInit() {}
}
