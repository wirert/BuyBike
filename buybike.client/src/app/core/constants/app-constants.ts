interface StringIndex {
  [key: string]: string | undefined;
}

export abstract class AppConstants {
  public static bikeTypes: StringIndex = {
    Mountain: 'Планински',
    Kids: 'Детски',
    Road: 'Шосеен',
    City: 'Градски',
    Electric: 'Електрически',
  };
}
