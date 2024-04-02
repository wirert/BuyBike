import { Component, Input, OnChanges } from '@angular/core';

@Component({
  selector: 'category-banner',
  standalone: true,
  imports: [],
  templateUrl: './banner.component.html',
  styleUrl: './banner.component.css',
})
export class CategoryBannerComponent {
  @Input() imageSrc: string = '';
}
