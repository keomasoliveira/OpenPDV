import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'currencyBrl',
  standalone: true
})
export class CurrencyBrlPipe implements PipeTransform {
  transform(value: number): string {
    return value.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' });
  }
}
