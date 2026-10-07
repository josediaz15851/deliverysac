namespace DeliverySac.API.Models;

public class CambioEstado
{
    public int Id { get; set; }
    public int PedidoId { get; set; }
    public int UsuarioId { get; set; }
    public EstadoPedido EstadoAnterior { get; set; }
    public EstadoPedido EstadoNuevo { get; set; }
    public DateTime Fecha { get; set; } = DateTime.UtcNow;

    public Pedido? Pedido { get; set; }
    public Usuario? Usuario { get; set; }
}
