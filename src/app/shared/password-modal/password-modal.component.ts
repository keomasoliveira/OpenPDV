import { CommonModule } from '@angular/common'; // Adicione esta linha
import { Component, Inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { BaseModalComponent } from '../base-modal/base-modal.component';

@Component({
  selector: 'app-password-modal',
  standalone: true,
  imports: [
    CommonModule, // Adicione CommonModule aqui
    FormsModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    BaseModalComponent,
  ],
  templateUrl: './password-modal.component.html',
  styleUrls: ['./password-modal.component.scss'],
})
export class PasswordModalComponent extends BaseModalComponent {
  password: string = '';
  hidePassword: boolean = true;
  showError: boolean = false;

  constructor(
    public dialogRef: MatDialogRef<PasswordModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    super();
  }

  onSubmit(): void {
    if (this.data.validatePassword(this.password)) {
      this.dialogRef.close(this.password);
    } else {
      this.showError = true;
    }
  }

  togglePasswordVisibility(): void {
    this.hidePassword = !this.hidePassword;
  }
}
