import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  email = '';
  password = '';
  errorMessage = '';
  isLoading = false;

  constructor(private authService: AuthService, private router: Router) {}

  login(): void {
    if (!this.email || !this.password) {
      this.errorMessage = 'Email y contraseña son requeridos';
      return;
    }

    this.isLoading = true;
    this.errorMessage = '';

    this.authService.login(this.email, this.password).subscribe({
      next: (response) => {
        this.isLoading = false;
        const rol = this.authService.getRoleFromToken();
        if (rol === 'Administrador') {
          this.router.navigate(['/admin']);
        } else if (rol === 'Repartidor') {
          this.router.navigate(['/repartidor']);
        } else if (rol === 'Supervisor') {
          this.router.navigate(['/supervisor']);
        }
      },
      error: (error) => {
        this.isLoading = false;
        this.errorMessage = 'Credenciales inválidas';
        console.error('Error de login:', error);
      }
    });
  }
}
