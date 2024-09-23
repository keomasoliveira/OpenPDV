import { Component, ElementRef, ViewChild, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-input-key',
  standalone: true,
  imports: [],
  templateUrl: './input-key.component.html',
  styleUrls: ['./input-key.component.scss']
})
export class InputKeyComponent {
  @ViewChild('inputElement') inputElement!: ElementRef;
  @Output() valueChange = new EventEmitter<string>();

  appendValue(value: string) {
    const newValue = this.inputElement.nativeElement.value + value;
    this.inputElement.nativeElement.value = newValue;
    this.valueChange.emit(newValue);
  }

  clearValue() {
    this.inputElement.nativeElement.value = '';
    this.valueChange.emit('');
  }
}
