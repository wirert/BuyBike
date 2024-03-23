import { CommonModule } from '@angular/common';
import { Component, ElementRef, Input, ViewChild } from '@angular/core';

@Component({
  selector: 'product-details',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.css',
})
export class ProductDetailsComponent {
  @Input() id: string | undefined;

  @ViewChild('imageDiv') imageDiv!: ElementRef;

  onMouseMoveOverPicture(event: any) {
    this.imageDiv.nativeElement.style.backgroundSize = '200%';
    this.imageDiv.nativeElement.style.backgroundPositionX =
      -event.offsetX + 'px';
    this.imageDiv.nativeElement.style.backgroundPositionY =
      -event.offsetY + 'px';
  }

  onMouseOutOfPicture() {
    this.imageDiv.nativeElement.style.backgroundSize = 'contain';
    this.imageDiv.nativeElement.style.backgroundPosition = 'center';
  }
}
