import { Component } from '@angular/core';
import { RouterModule } from '@angular/router'; // Import RouterModule
import { SidebarComponent } from './shared/sidebar/sidebar.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  standalone: true,
  imports: [RouterModule, SidebarComponent], // Add RouterModule and SidebarComponent to imports
})
export class AppComponent {
  title = 'OpenPDV';

  sidebarButtons = [
    { icon: 'manage_accounts', label: 'Gerencial', selected: true },
    { icon: 'fastfood', label: 'Item Rápido' },
    { icon: 'settings', label: 'Admin TEF' },
  ];
}
