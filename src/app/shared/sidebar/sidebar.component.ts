import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';

interface SidebarButton {
  icon: string;
  label: string;
  selected?: boolean;
}

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [CommonModule, MatIconModule],
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent {
  @Input() buttons: SidebarButton[] = [
    { icon: 'assessment', label: 'Gerencial', selected: true },
    { icon: 'fastfood', label: 'Item Rápido' },
    { icon: 'settings', label: 'Admin TEF' }
  ];
}
