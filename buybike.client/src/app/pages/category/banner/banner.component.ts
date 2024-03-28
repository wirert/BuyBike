import { Component, Input, OnChanges } from '@angular/core';

@Component({
  selector: 'category-banner',
  standalone: true,
  imports: [],
  templateUrl: './banner.component.html',
  styleUrl: './banner.component.css',
})
export class CategoryBannerComponent implements OnChanges {
  private previousType: string | null = null;

  @Input() categoryType: string | null = null;
  imageSrc: string = '';

  ngOnChanges(): void {
    if (this.previousType !== this.categoryType) {
      this.previousType = this.categoryType;

      switch (this.categoryType) {
        case 'mountain':
          this.imageSrc =
            '../../../../assets/category-banner/mountain-unsplash.jpg';
          break;
        case 'city':
          this.imageSrc =
            '../../../../assets/category-banner/city-unsplash.jpg';
          break;
        case 'road':
          this.imageSrc =
            '../../../../assets/category-banner/road-unsplash.jpg';
          break;
        case 'electric':
          this.imageSrc =
            '../../../../assets/category-banner/ebikes-unsplash.jpg';
          break;
        case 'kids':
          this.imageSrc =
            '../../../../assets/category-banner/kids-unsplash.jpg';
          break;
        default:
          this.imageSrc = '../../../../assets/news/field.jpg';
          break;
      }
    }
  }
}
