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

interface CambioEstado {
  id: number;
  pedidoId: number;
  usuarioEmail: string;
  estadoAnterior: string;
  estadoNuevo: string;
  fecha: string;
}

interface PaginatedResponse {
  data: Pedido[];
  page: number;
  size: number;
  total: number;
}

@Component({
  selector: 'app-supervisor',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './supervisor.component.html',
  styleUrls: ['./supervisor.component.css']
})
export class SupervisorComponent implements OnInit {
  private http = inject(HttpClient);

  pedidos: Pedido[] = [];
  cambiosHistorial: CambioEstado[] = [];
  page = 1;
  size = 10;
  total = 0;
  cargando = false;
  cargandoHistorial = false;
  errorMessage = '';
  estadoFiltro = '';
  pedidoSeleccionado: Pedido | null = null;
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

  verHistorial(pedido: Pedido) {
    this.pedidoSeleccionado = pedido;
    this.cargandoHistorial = true;
    this.errorMessage = '';

    const url = `http://localhost:5000/api/cambioestado/${pedido.id}`;

    this.http.get<CambioEstado[]>(url).subscribe({
      next: (response: CambioEstado[]) => {
        this.cambiosHistorial = response;
        this.cargandoHistorial = false;
      },
      error: (err: any) => {
        this.errorMessage = 'Error al cargar historial';
        this.cargandoHistorial = false;
      }
    });
  }

  cerrarHistorial() {
    this.pedidoSeleccionado = null;
    this.cambiosHistorial = [];
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
