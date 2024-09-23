import { Component } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { CurrencyBrlPipe } from '../../shared/currency-brl.pipe';

@Component({
  selector: 'app-last-item',
  standalone: true,
  imports: [MatIconModule, CurrencyBrlPipe],
  templateUrl: './last-item.component.html',
  styleUrl: './last-item.component.scss',
})
export class LastItemComponent {}
