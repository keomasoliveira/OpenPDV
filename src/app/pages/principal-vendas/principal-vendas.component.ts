import { CommonModule } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { RouterModule } from '@angular/router'; // Import RouterModule
import { LastItemComponent } from '../../components/last-item/last-item.component';
import { ButtonKeyComponent } from '../../shared/button-key/button-key.component';
import { ButtonPanelComponent } from '../../shared/button-panel/button-panel.component';
import { InputKeyComponent } from '../../shared/input-key/input-key.component';
import { TableComponent } from '../../shared/table/table.component';

@Component({
  selector: 'app-principal-vendas',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule, // Add RouterModule to imports
    ButtonPanelComponent,
    ButtonKeyComponent,
    TableComponent,
    InputKeyComponent,
    LastItemComponent,
  ],
  templateUrl: './principal-vendas.component.html',
  styleUrls: ['./principal-vendas.component.scss'],
})
export class PrincipalVendasComponent implements OnInit {
  @ViewChild(InputKeyComponent) inputKeyComponent!: InputKeyComponent;

  tableData: any[] = [];
  inputValue: string = '';

  ngOnInit() {
    this.tableData = [
      {
        '#': '001',
        PRODUTO: 'Produto 1',
        BARRA: '789100005512',
        'PREÇO UNIT': 10.5,
        QTD: 2,
        TOTAL: 21.0,
      },
      {
        '#': '002',
        PRODUTO: 'Produto 2',
        BARRA: '789600740151',
        'PREÇO UNIT': 15.75,
        QTD: 1,
        TOTAL: 15.75,
      },
    ];
  }

  onButtonClick(key: string) {
    this.inputValue += key;
    this.inputKeyComponent.setValue(this.inputValue);
  }

  onInputCleared() {
    this.inputValue = '';
  }

  sidebarButtons = [
    { icon: 'manage_accounts', label: 'Gerencial', selected: true },
    { icon: 'fastfood', label: 'Item Rápido' },
    { icon: 'settings', label: 'Admin TEF' },
  ];
}
