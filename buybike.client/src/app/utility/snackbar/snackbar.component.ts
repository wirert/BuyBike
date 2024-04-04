import { Component, Input } from '@angular/core';

@Component({
  standalone: true,
  selector: 'app-snackbar',
  templateUrl: './snackbar.component.html',
  styleUrls: ['./snackbar.component.css'],
})
export class SnackbarComponent {
  @Input() errorMessage: string | null = null;
}
