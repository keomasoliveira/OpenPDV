import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-input-key',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './input-key.component.html',
  styleUrls: ['./input-key.component.scss'],
})
export class InputKeyComponent {
  @Input() value: string = '';
  @Output() valueChange = new EventEmitter<string>();
  @Output() cleared = new EventEmitter<void>();

  setValue(newValue: string) {
    this.value = newValue;
    this.valueChange.emit(this.value);
  }

  clearInput() {
    this.value = '';
    this.valueChange.emit(this.value);
    this.cleared.emit();
  }
}
