namespace DeliverySac.API.Models;

public class Asignacion
{
    public int Id { get; set; }
    public int PedidoId { get; set; }
    public int RepartidorId { get; set; }
    public DateTime FechaAsignacion { get; set; } = DateTime.UtcNow;
    public DateTime? FechaEntrega { get; set; }

    public Pedido? Pedido { get; set; }
    public Usuario? Repartidor { get; set; }
}
