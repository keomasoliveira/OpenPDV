import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private managerPassword = '123456'; // Senha gerencial (em um cenário real, isso seria armazenado de forma segura)

  validateManagerPassword(password: string): boolean {
    return password === this.managerPassword;
  }
}
