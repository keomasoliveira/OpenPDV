import { CommonModule } from '@angular/common';
import { Component, ElementRef, Input, ViewChild } from '@angular/core';
import { CurrencyBrlPipe } from '../currency-brl.pipe';

@Component({
  selector: 'app-table',
  standalone: true,
  imports: [CommonModule, CurrencyBrlPipe],
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss'],
  providers: [CurrencyBrlPipe],
})
export class TableComponent {
  @Input() columns: string[] = [];
  @Input() data: any[] = [];
  @Input() columnColors: { [key: string]: string } = {};
  @Input() idHeader: string = 'ID';
  @Input() currencyMask: string[] = [];

  @ViewChild('tableBody', { static: false }) tableBody!: ElementRef;

  constructor(private currencyBrlPipe: CurrencyBrlPipe) {}

  getCellValue(row: any, column: string): string {
    return this.currencyMask.includes(column)
      ? this.currencyBrlPipe.transform(row[column])
      : row[column];
  }

  getBarWidth(row: any): number {
    const maxValue = 100;
    const value = row['TOTITEM'] || 0;
    return (value / maxValue) * 100;
  }

  scrollToLastItem() {
    if (this.tableBody && typeof window !== 'undefined') {
      const lastRow = this.tableBody.nativeElement.lastElementChild;
      if (lastRow && typeof lastRow.scrollIntoView === 'function') {
        lastRow.scrollIntoView({ behavior: 'smooth', block: 'end' });
      }
    }
  }
}
