import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

interface Pedido {
  id: number;
  clienteId: number;
  clienteNombre: string;
  descripcion: string;
  monto: number;
  estado: string;
  fechaCreacion: string;
  fechaActualizacion: string;
}

interface PaginatedResponse {
  data: Pedido[];
  page: number;
  size: number;
  total: number;
}

@Component({
  selector: 'app-admin',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  private http = inject(HttpClient);

  pedidos: Pedido[] = [];
  estadoFiltro = '';
  page = 1;
  size = 10;
  total = 0;
  cargando = false;
  errorMessage = '';
  estados = ['PENDIENTE', 'ASIGNADO', 'EN_RUTA', 'ENTREGADO', 'NO_ENTREGADO', 'REPROGRAMADO'];

  ngOnInit() {
    this.cargarPedidos();
  }

  cargarPedidos() {
    this.cargando = true;
    this.errorMessage = '';

    let url = `http://localhost:5000/api/pedido?page=${this.page}&size=${this.size}`;
    if (this.estadoFiltro) {
      url += `&estado=${this.estadoFiltro}`;
    }

    this.http.get<PaginatedResponse>(url).subscribe({
      next: (response: PaginatedResponse) => {
        this.pedidos = response.data;
        this.total = response.total;
        this.cargando = false;
      },
      error: (err: any) => {
        this.errorMessage = 'Error al cargar pedidos';
        this.cargando = false;
      }
    });
  }

  filtrarPorEstado(estado: string) {
    this.estadoFiltro = estado;
    this.page = 1;
    this.cargarPedidos();
  }

  cambiarPagina(nuevaPagina: number) {
    this.page = nuevaPagina;
    this.cargarPedidos();
  }

  obtenerTotalPaginas(): number {
    return Math.ceil(this.total / this.size);
  }

  logout() {
    localStorage.removeItem('jwt_token');
    window.location.href = '/login';
  }
}
