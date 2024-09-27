import { Injectable } from '@angular/core';
import { MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import { PasswordModalComponent } from '../shared/password-modal/password-modal.component';

@Injectable({
  providedIn: 'root',
})
export class ModalService {
  constructor(private dialog: MatDialog) {}

  openPasswordModal(
    validatePassword: (password: string) => boolean
  ): MatDialogRef<PasswordModalComponent> {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '400px';
    dialogConfig.height = '300px';
    dialogConfig.panelClass = 'custom-dialog-container';
    dialogConfig.data = { validatePassword };

    return this.dialog.open(PasswordModalComponent, dialogConfig);
  }
}
