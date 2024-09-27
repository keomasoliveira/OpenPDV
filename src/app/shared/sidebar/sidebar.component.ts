import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';

export interface SidebarButton {
  icon: string;
  label: string;
  selected?: boolean;
  subItems?: SidebarButton[];
  expanded?: boolean;
}

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [CommonModule, MatIconModule],
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss'],
})
export class SidebarComponent {
  @Input() buttons: SidebarButton[] = [];
  @Output() toggleSubItems = new EventEmitter<SidebarButton>();

  toggleSubItemsInternal(button: SidebarButton) {
    button.expanded = !button.expanded;
    // Feche outros itens expandidos
    this.buttons.forEach(b => {
      if (b !== button) {
        b.expanded = false;
      }
    });
  }

  onToggleSubItems(button: SidebarButton): void {
    this.toggleSubItems.emit(button);
  }
}
