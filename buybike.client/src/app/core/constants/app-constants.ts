import { InjectionToken } from '@angular/core';

interface StringIndex {
  [key: string]: string | undefined;
}

export abstract class AppConstants {
  //   public static bikeTypes: StringIndex = {
  //     Mountain: 'Планински',
  //     Kids: 'Детски',
  //     Road: 'Шосеен',
  //     City: 'Градски',
  //     Electric: 'Електрически',
  //   };

  public static productTypes: StringIndex = {
    велосипеди: 'Bicycle',
    части: 'Part',
    аксесоари: 'Accessory',
    екипировка: 'Equipment',
  };
}

export const API_URL = new InjectionToken<string>('');
