import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { LastItemComponent } from '../../components/last-item/last-item.component';
import { ModalService } from '../../services/modal.service';
import { ButtonKeyComponent } from '../../shared/button-key/button-key.component';
import { ButtonPanelComponent } from '../../shared/button-panel/button-panel.component';
import { InputKeyComponent } from '../../shared/input-key/input-key.component';
import { TableComponent } from '../../shared/table/table.component';

@Component({
  selector: 'app-principal-vendas',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
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
  tableData: any[] = [];
  inputValue: string = '';

  constructor(private modalService: ModalService) {}

  ngOnInit() {
    this.generateTableData();
  }

  generateTableData() {
    this.tableData = [];
    for (let i = 1; i <= 60; i++) {
      this.tableData.push({
        '#': String(i).padStart(3, '0'),
        PRODUTO: `Produto ${i}`,
        BARRA: `7891000055${String(i).padStart(2, '0')}`,
        'PREÇO UNIT': (Math.random() * 100).toFixed(2),
        QTD: Math.floor(Math.random() * 10) + 1,
        TOTAL: 0,
      });
    }

    this.tableData.forEach(item => {
      item.TOTAL = (parseFloat(item['PREÇO UNIT']) * item.QTD).toFixed(2);
    });
  }

  onButtonClick(key: string) {
    this.inputValue += key;
  }

  onInputCleared() {
    this.inputValue = '';
  }

  onFinalizarCompra() {
    console.log('Compra Finalizada');
  }

  onCancelarCompra() {
    console.log('Compra cancelada');
  }

  sidebarButtons = [
    { icon: 'manage_accounts', label: 'Gerencial', selected: true },
    { icon: 'fastfood', label: 'Item Rápido' },
    { icon: 'settings', label: 'Admin TEF' },
  ];
}
