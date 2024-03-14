import { CommonModule } from '@angular/common';
import {
  AfterViewInit,
  Component,
  EventEmitter,
  Input,
  OnInit,
  Output,
  ViewChild,
} from '@angular/core';

@Component({
  selector: 'app-paginator',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './paginator.component.html',
  styleUrl: './paginator.component.css',
})
export class PaginatorComponent implements AfterViewInit, OnInit {
  @Input() totalItems: number = 0;
  @Input() itemsPerPage: number = 12;
  @Input() currentPage: number = 1;
  @Output() pageChanged: EventEmitter<number> = new EventEmitter();
  @Output() itemPerPageChanged: EventEmitter<number> = new EventEmitter();
  @Output() sortingChanged: EventEmitter<{ orderBy: string; desc: boolean }> =
    new EventEmitter();

  orderBy: string = 'price';
  isDescending: boolean = false;

  ngOnInit(): void {}

  ngAfterViewInit(): void {}

  get totalPages(): number {
    return Math.ceil(this.totalItems / this.itemsPerPage);
  }

  changePage(page: number): void {
    if (page >= 1 && page <= this.totalPages) {
      this.currentPage = page;
      this.pageChanged.emit(page);
    }
  }

  changeItemPerPage(event: any) {
    const itemsCountPerPage: number = event.target.value;

    if (this.itemsPerPage !== itemsCountPerPage) {
      this.itemsPerPage = itemsCountPerPage;
      this.itemPerPageChanged.emit(itemsCountPerPage);
    }
  }

  changeSorting(event: any) {
    const orderBy: string = event.target.value;

    if (this.orderBy !== orderBy) {
      this.orderBy = orderBy;
      this.sortingChanged.emit({ orderBy, desc: this.isDescending });
    }
  }

  reverseSorting() {
    this.isDescending = !this.isDescending;

    this.sortingChanged.emit({
      orderBy: this.orderBy,
      desc: this.isDescending,
    });
  }
}
