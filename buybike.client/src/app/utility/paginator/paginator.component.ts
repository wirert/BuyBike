import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { PaginatorState } from '../../core/models/paginator-state';

@Component({
  selector: 'app-paginator',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './paginator.component.html',
  styleUrl: './paginator.component.css',
})
export class PaginatorComponent {
  @Input() totalItems: number = 0;
  @Output() paginatorStateChanged: EventEmitter<PaginatorState> =
    new EventEmitter();

  paginatorState: PaginatorState = new PaginatorState();

  get totalPages(): number {
    return Math.ceil(this.totalItems / this.paginatorState.itemsPerPage);
  }

  changePage(page: number): void {
    if (page >= 1 && page <= this.totalPages) {
      this.paginatorState.pageNumber = page;
      this.paginatorStateChanged.emit(this.paginatorState);
    }
  }

  changeItemPerPage(event: any) {
    const itemsCountPerPage: number = event.target.value;

    if (this.paginatorState.itemsPerPage !== itemsCountPerPage) {
      this.paginatorState.itemsPerPage = itemsCountPerPage;
      this.paginatorState.pageNumber = 1;
      this.paginatorStateChanged.emit(this.paginatorState);
    }
  }

  changeSorting(event: any) {
    const orderBy: string = event.target.value;

    if (this.paginatorState.orderBy !== orderBy) {
      this.paginatorState.orderBy = orderBy;
      this.paginatorStateChanged.emit(this.paginatorState);
    }
  }

  reverseSorting() {
    this.paginatorState.desc = !this.paginatorState.desc;
    this.paginatorStateChanged.emit(this.paginatorState);
  }
}
