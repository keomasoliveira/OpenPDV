import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-button-panel',
  standalone: true,
  imports: [CommonModule, MatIconModule],
  templateUrl: './button-panel.component.html',
  styleUrls: ['./button-panel.component.scss']
})
export class ButtonPanelComponent {
  @Input() disabled: boolean = false;
  @Input() key: string = '';
  @Input() name: string = '';
  @Input() icon?: string = '';
  @Input() buttonClass: string = 'btn-primary';
  @Output() buttonClick = new EventEmitter<void>();

  onClick() {
    if (!this.disabled) {
      this.buttonClick.emit();
    }
  }
}
