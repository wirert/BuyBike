import { provideHttpClient } from '@angular/common/http';
import { ApplicationConfig } from '@angular/core';
import {
  provideRouter,
  withComponentInputBinding,
  UrlSerializer,
  withRouterConfig,
} from '@angular/router';
import routes from './app-routes';
import { API_URL } from './core/constants/app-constants';
import { LowerCaseUrlSerializer } from './lowerCaseUrlSerializer';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(
      routes,
      withComponentInputBinding(),
      withRouterConfig({ onSameUrlNavigation: 'reload' })
    ),
    { provide: API_URL, useValue: 'https://localhost:7129/api' },
    provideHttpClient(),
    {
      provide: UrlSerializer,
      useClass: LowerCaseUrlSerializer,
    },
  ],
};
