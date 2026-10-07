import { Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';

export const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'admin', component: LoginComponent }, // Placeholder
  { path: 'repartidor', component: LoginComponent }, // Placeholder
  { path: 'supervisor', component: LoginComponent }, // Placeholder
  { path: '**', redirectTo: '/login' }
];
