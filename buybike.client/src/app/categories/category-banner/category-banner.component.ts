import {
  AfterContentChecked,
  Component,
  DoCheck,
  Input,
  OnChanges,
  OnInit,
  SimpleChanges,
  inject,
} from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'category-banner',
  standalone: true,
  imports: [],
  templateUrl: './category-banner.component.html',
  styleUrl: './category-banner.component.css',
})
export class CategoryBannerComponent implements OnChanges {
  @Input() categoryType: string | null = null;
  activatedRoute: ActivatedRoute = inject(ActivatedRoute);
  imageSrc: string = '';
  previousType: string | null = null;

  ngOnChanges(): void {
    switch (this.categoryType) {
      case 'mountain':
        this.imageSrc = '../../../assets/category-banner/mountain-unsplash.jpg';
        break;
      case 'city':
        this.imageSrc = '../../../assets/category-banner/city-unsplash.jpg';
        break;
      case 'road':
        this.imageSrc = '../../../assets/category-banner/road-unsplash.jpg';
        break;
      case 'electric':
        this.imageSrc = '../../../assets/category-banner/ebikes-unsplash.jpg';
        break;
      case 'kids':
        this.imageSrc = '../../../assets/category-banner/kids-unsplash.jpg';
        break;
      default:
        this.imageSrc = '../../../assets/news/field.jpg';
        break;
    }
  }
}
