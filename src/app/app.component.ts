import { Component, ViewChild } from '@angular/core';
import { ButtonPanelComponent } from './shared/button-panel/button-panel.component';
import { ButtonKeyComponent } from './shared/button-key/button-key.component';
import { TableComponent } from './shared/table/table.component';
import { InputKeyComponent } from './shared/input-key/input-key.component';
import { SidebarComponent } from './shared/sidebar/sidebar.component';
import { LastItemComponent } from './components/last-item/last-item.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  standalone: true,
  imports: [
    ButtonPanelComponent,
    ButtonKeyComponent,
    TableComponent,
    InputKeyComponent,
    SidebarComponent,
    LastItemComponent,
  ],
})
export class AppComponent {
  title = 'OpenPDV';

  @ViewChild(InputKeyComponent) inputKeyComponent!: InputKeyComponent;

  tableData = [
    {
      ID: '001',
      BARRA: '7894900010015',
      DESCRICAO: 'COCA COLA LATA 350ML UN',
      QTD: 1,
      VALORUNIT: 3.5,
      TOTITEM: 3.5,
    },
    {
      ID: '002',
      BARRA: '7892840813055',
      DESCRICAO: 'PEPSI LATA 350ML UN',
      QTD: 2,
      VALORUNIT: 3.0,
      TOTITEM: 6.0,
    },
    {
      ID: '003',
      BARRA: '7894900031201',
      DESCRICAO: 'FANTA LARANJA LATA 350ML UN',
      QTD: 1,
      VALORUNIT: 3.2,
      TOTITEM: 3.2,
    },
    {
      ID: '004',
      BARRA: '7896065220011',
      DESCRICAO: 'AGUA MINERAL MONTE ALTO SEM GAS 500ML UN',
      QTD: 3,
      VALORUNIT: 2.5,
      TOTITEM: 7.5,
    },
    {
      ID: '005',
      BARRA: '7896102501005',
      DESCRICAO: 'SUCO DE UVA PIRAQUARA INTEGRAL 300ML UN',
      QTD: 1,
      VALORUNIT: 4.0,
      TOTITEM: 4.0,
    },
  ];

  onButtonClick(value: string) {
    this.inputKeyComponent.appendValue(value);
  }

  onInputCleared() {
    this.inputKeyComponent.clearValue();
  }

  sidebarButtons = [
    { icon: 'manage_accounts', label: 'Gerencial', selected: true },
    { icon: 'fastfood', label: 'Item Rápido' },
    { icon: 'settings', label: 'Admin TEF' },
  ];
}
