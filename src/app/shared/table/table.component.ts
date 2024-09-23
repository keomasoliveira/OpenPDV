import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CurrencyBrlPipe } from '../currency-brl.pipe';

@Component({
  selector: 'app-table',
  standalone: true,
  imports: [CommonModule, CurrencyBrlPipe],
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss'],
  providers: [CurrencyBrlPipe], // Add this line to provide the pipe
})
export class TableComponent {
  @Input() columns: string[] = [];
  @Input() data: any[] = [];
  @Input() columnColors: { [key: string]: string } = {};
  @Input() idHeader: string = 'ID';
  @Input() currencyMask: string[] = [];

  constructor(private currencyBrlPipe: CurrencyBrlPipe) {} // Inject the pipe

  getCellValue(row: any, column: string): string {
    return this.currencyMask.includes(column)
      ? this.currencyBrlPipe.transform(row[column])
      : row[column];
  }

  // Adicione este método
  getBarWidth(row: any): number {
    // Implemente a lógica para calcular a largura da barra aqui
    // Por exemplo, você pode usar um valor máximo e calcular a porcentagem
    const maxValue = 100; // Defina o valor máximo apropriado
    const value = row['TOTITEM'] || 0; // Assume que TOTITEM é o valor para a barra
    return (value / maxValue) * 100;
  }
}
