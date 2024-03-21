import { DefaultUrlSerializer, UrlTree } from '@angular/router';

export class LowerCaseUrlSerializer extends DefaultUrlSerializer {
  override parse(url: string): UrlTree {
    // Optional Step: You can perform additional processing on the URL here.
    // If you lower it in this step, you won't need to use "toLowerCase"
    // when passing it down to the next function.
    return super.parse(url.toLowerCase());
  }
}
