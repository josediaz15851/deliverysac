using DeliverySac.API.Data;
using DeliverySac.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeliverySac.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PedidoController : ControllerBase
{
    private readonly DeliverySacDbContext _context;

    public PedidoController(DeliverySacDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<PedidoDto>> CreatePedido([FromBody] CreatePedidoRequest request)
    {
        if (string.IsNullOrEmpty(request.Descripcion) || request.Monto <= 0)
            return BadRequest("Descripción y monto válido son requeridos");

        var cliente = await _context.Clientes.FindAsync(request.ClienteId);
        if (cliente == null)
            return BadRequest("Cliente no existe");

        var pedido = new Pedido
        {
            ClienteId = request.ClienteId,
            Descripcion = request.Descripcion,
            Monto = request.Monto,
            Estado = EstadoPedido.PENDIENTE,
            FechaCreacion = DateTime.UtcNow,
            FechaActualizacion = DateTime.UtcNow
        };

        _context.Pedidos.Add(pedido);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPedido), new { id = pedido.Id }, ToDto(pedido));
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResponse<PedidoDto>>> GetPedidos([FromQuery] int page = 1, [FromQuery] int size = 10, [FromQuery] string? estado = null)
    {
        if (page < 1 || size < 1)
            return BadRequest("page y size deben ser mayores que 0");

        var query = _context.Pedidos.Include(p => p.Cliente).AsQueryable();

        if (!string.IsNullOrEmpty(estado) && Enum.TryParse<EstadoPedido>(estado, out var estadoEnum))
            query = query.Where(p => p.Estado == estadoEnum);

        var total = await query.CountAsync();
        var pedidos = await query
            .OrderByDescending(p => p.FechaCreacion)
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();

        var response = new PaginatedResponse<PedidoDto>
        {
            Data = pedidos.Select(ToDto).ToList(),
            Page = page,
            Size = size,
            Total = total
        };

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PedidoDto>> GetPedido(int id)
    {
        var pedido = await _context.Pedidos.Include(p => p.Cliente).FirstOrDefaultAsync(p => p.Id == id);
        if (pedido == null)
            return NotFound();

        return Ok(ToDto(pedido));
    }

    private static PedidoDto ToDto(Pedido pedido)
    {
        return new PedidoDto
        {
            Id = pedido.Id,
            ClienteId = pedido.ClienteId,
            ClienteNombre = pedido.Cliente?.Nombre ?? string.Empty,
            Descripcion = pedido.Descripcion,
            Monto = pedido.Monto,
            Estado = pedido.Estado.ToString(),
            FechaCreacion = pedido.FechaCreacion,
            FechaActualizacion = pedido.FechaActualizacion
        };
    }
}

public class CreatePedidoRequest
{
    public int ClienteId { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public decimal Monto { get; set; }
}

public class PedidoDto
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public string ClienteNombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public decimal Monto { get; set; }
    public string Estado { get; set; } = string.Empty;
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaActualizacion { get; set; }
}
