import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

interface Asignacion {
  id: number;
  pedidoId: number;
  pedidoDescripcion: string;
  repartidorId: number;
  repartidorEmail: string;
  fechaAsignacion: string;
  fechaEntrega: string | null;
}

interface PaginatedResponse {
  data: Asignacion[];
  page: number;
  size: number;
  total: number;
}

@Component({
  selector: 'app-repartidor',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './repartidor.component.html',
  styleUrls: ['./repartidor.component.css']
})
export class RepartidorComponent implements OnInit {
  private http = inject(HttpClient);

  asignaciones: Asignacion[] = [];
  page = 1;
  size = 10;
  total = 0;
  cargando = false;
  errorMessage = '';
  successMessage = '';
  repartidorId = 0;
  selectedAsignacionId: number | null = null;
  nuevoEstado = '';
  estados = ['EN_RUTA', 'ENTREGADO', 'NO_ENTREGADO', 'REPROGRAMADO'];

  ngOnInit() {
    this.obtenerRepartidorId();
    this.cargarAsignaciones();
  }

  obtenerRepartidorId() {
    const token = localStorage.getItem('jwt_token');
    if (token) {
      const payload = JSON.parse(atob(token.split('.')[1]));
      this.repartidorId = payload.sub || 0;
    }
  }

  cargarAsignaciones() {
    this.cargando = true;
    this.errorMessage = '';

    const url = `http://localhost:5000/api/asignacion?page=${this.page}&size=${this.size}&repartidorId=${this.repartidorId}`;

    this.http.get<PaginatedResponse>(url).subscribe({
      next: (response: PaginatedResponse) => {
        this.asignaciones = response.data;
        this.total = response.total;
        this.cargando = false;
      },
      error: (err: any) => {
        this.errorMessage = 'Error al cargar asignaciones';
        this.cargando = false;
      }
    });
  }

  cambiarPagina(nuevaPagina: number) {
    this.page = nuevaPagina;
    this.cargarAsignaciones();
  }

  obtenerTotalPaginas(): number {
    return Math.ceil(this.total / this.size);
  }

  cambiarEstado(asignacionId: number) {
    this.selectedAsignacionId = asignacionId;
  }

  guardarCambioEstado() {
    if (!this.selectedAsignacionId || !this.nuevoEstado) {
      this.errorMessage = 'Selecciona un estado válido';
      return;
    }

    const asignacion = this.asignaciones.find(a => a.id === this.selectedAsignacionId);
    if (!asignacion) return;

    const payload = {
      pedidoId: asignacion.pedidoId,
      estadoNuevo: this.nuevoEstado
    };

    this.http.post('http://localhost:5000/api/cambioestado/cambiar', payload).subscribe({
      next: (response: any) => {
        this.successMessage = `Estado actualizado a ${this.nuevoEstado}`;
        this.selectedAsignacionId = null;
        this.nuevoEstado = '';
        setTimeout(() => this.cargarAsignaciones(), 1000);
      },
      error: (err: any) => {
        this.errorMessage = err.error?.message || 'Error al cambiar estado';
      }
    });
  }

  cancelarCambio() {
    this.selectedAsignacionId = null;
    this.nuevoEstado = '';
  }

  logout() {
    localStorage.removeItem('jwt_token');
    window.location.href = '/login';
  }
}
