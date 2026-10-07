namespace DeliverySac.API.Models;

public enum EstadoPedido
{
    PENDIENTE,
    ASIGNADO,
    EN_RUTA,
    ENTREGADO,
    NO_ENTREGADO,
    REPROGRAMADO
}

public class Pedido
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public decimal Monto { get; set; }
    public EstadoPedido Estado { get; set; } = EstadoPedido.PENDIENTE;
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    public DateTime FechaActualizacion { get; set; } = DateTime.UtcNow;

    public Cliente? Cliente { get; set; }
}
