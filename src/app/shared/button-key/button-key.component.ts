import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-button-key',
  standalone: true,
  imports: [],
  templateUrl: './button-key.component.html',
  styleUrl: './button-key.component.scss'
})
export class ButtonKeyComponent {
  @Input() keyCaption: string = '';
  @Output() buttonClick = new EventEmitter<void>();

  onClick() {
    this.buttonClick.emit();
  }
}
