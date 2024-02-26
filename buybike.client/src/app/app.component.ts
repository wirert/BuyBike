import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, OnInit, inject } from '@angular/core';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { HomeComponent } from './home/home.component';
import { RouterModule } from '@angular/router';

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
    RouterModule,
    HttpClientModule,
  ],
})
export class AppComponent implements OnInit {
  public forecasts: WeatherForecast[] = [];

  private http: HttpClient = inject(HttpClient);

  ngOnInit() {
    //this.getForecasts();
  }

  getForecasts() {
    this.http
      .get<WeatherForecast[]>('https://localhost:7129/WeatherForecast')
      .subscribe({
        next: (result) => {
          this.forecasts = result;
          console.log(result);
        },
        error: (error) => {
          console.error(error);
          console.log('there is an error');
        },
      });
  }

  title = 'buybike.client';
}
