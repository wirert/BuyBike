import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import {
  UrlSerializer,
  provideRouter,
  withComponentInputBinding,
} from '@angular/router';
import routes from './app/app-routes';
import { provideHttpClient } from '@angular/common/http';
import { LowerCaseUrlSerializer } from './app/lowerCaseUrlSerializer';
import { API_URL } from './app/core/constants/app-constants';

bootstrapApplication(AppComponent, {
  providers: [
    provideRouter(routes, withComponentInputBinding()),
    { provide: API_URL, useValue: 'https://localhost:7129/api' },
    provideHttpClient(),
    {
      provide: UrlSerializer,
      useClass: LowerCaseUrlSerializer,
    },
  ],
}).catch((err) => console.log(err));
