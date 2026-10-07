import { Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { AdminComponent } from './admin/admin.component';
import { RepartidorComponent } from './repartidor/repartidor.component';
import { SupervisorComponent } from './supervisor/supervisor.component';

export const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'admin', component: AdminComponent },
  { path: 'repartidor', component: RepartidorComponent },
  { path: 'supervisor', component: SupervisorComponent },
  { path: '**', redirectTo: '/login' }
];
