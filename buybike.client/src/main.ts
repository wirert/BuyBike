import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import { UrlSerializer, provideRouter } from '@angular/router';
import routes from './app/app-routes';
import { provideHttpClient } from '@angular/common/http';
import { LowerCaseUrlSerializer } from './app/lowerCaseUrlSerializer';

bootstrapApplication(AppComponent, {
  providers: [
    provideRouter(routes),
    provideHttpClient(),
    {
      provide: UrlSerializer,
      useClass: LowerCaseUrlSerializer,
    },
  ],
}).catch((err) => console.log(err));
