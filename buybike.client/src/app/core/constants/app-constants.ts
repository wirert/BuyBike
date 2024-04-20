import { InjectionToken } from '@angular/core';

interface StringIndex {
  [key: string]: string | undefined;
}

export abstract class AppConstants {
  public static productTypes: StringIndex = {
    велосипеди: 'Велосипеди',
    части: 'Части',
    аксесоари: 'Аксесоари',
    екипировка: 'Екипировка',
  };
}

export const API_URL = new InjectionToken<string>('');
