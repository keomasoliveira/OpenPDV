import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AuthService } from './services/auth.service';
import { ModalService } from './services/modal.service';
import { SidebarButton, SidebarComponent } from './shared/sidebar/sidebar.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, SidebarComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  sidebarButtons: SidebarButton[] = [
    {
      icon: 'manage_accounts',
      label: 'Gerencial',
      selected: true,
      subItems: [
        { icon: 'print', label: 'Selecionar impressora' },
        { icon: 'point_of_sale', label: 'Efetuar Fechamento de caixa' },
        { icon: 'payments', label: 'Fazer Sangria' },
      ],
    },
    { icon: 'fastfood', label: 'Item Rápido' },
    { icon: 'settings', label: 'Admin TEF' },
  ];

  constructor(
    private modalService: ModalService,
    private authService: AuthService
  ) {}

  onToggleSubItems(button: SidebarButton): void {
    if (button.subItems && !button.expanded) {
      this.openPasswordModal(button);
    } else {
      button.expanded = !button.expanded;
    }
  }

  private openPasswordModal(button: SidebarButton): void {
    const dialogRef = this.modalService.openPasswordModal(
      this.authService.validateManagerPassword.bind(this.authService)
    );

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        button.expanded = true;
      }
    });
  }
}
