using DeliverySac.API.Data;
using DeliverySac.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeliverySac.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AsignacionController : ControllerBase
{
    private readonly DeliverySacDbContext _context;

    public AsignacionController(DeliverySacDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<AsignacionDto>> CreateAsignacion([FromBody] CreateAsignacionRequest request)
    {
        var pedido = await _context.Pedidos.FindAsync(request.PedidoId);
        if (pedido == null)
            return BadRequest("Pedido no existe");

        if (pedido.Estado != EstadoPedido.PENDIENTE)
            return BadRequest("Solo se pueden asignar pedidos en estado PENDIENTE");

        var repartidor = await _context.Usuarios.FindAsync(request.RepartidorId);
        if (repartidor == null)
            return BadRequest("Repartidor no existe");

        if (repartidor.Rol != "Repartidor")
            return BadRequest("El usuario no es un repartidor");

        var existente = await _context.Asignaciones
            .FirstOrDefaultAsync(a => a.PedidoId == request.PedidoId && a.FechaEntrega == null);
        if (existente != null)
            return BadRequest("El pedido ya está asignado");

        var asignacion = new Asignacion
        {
            PedidoId = request.PedidoId,
            RepartidorId = request.RepartidorId,
            FechaAsignacion = DateTime.UtcNow
        };

        pedido.Estado = EstadoPedido.ASIGNADO;
        pedido.FechaActualizacion = DateTime.UtcNow;

        _context.Asignaciones.Add(asignacion);
        _context.Pedidos.Update(pedido);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAsignacion), new { id = asignacion.Id }, ToDto(asignacion, pedido, repartidor));
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResponse<AsignacionDto>>> GetAsignaciones([FromQuery] int page = 1, [FromQuery] int size = 10, [FromQuery] int? repartidorId = null)
    {
        if (page < 1 || size < 1)
            return BadRequest("page y size deben ser mayores que 0");

        var query = _context.Asignaciones
            .Include(a => a.Pedido)
            .Include(a => a.Repartidor)
            .AsQueryable();

        if (repartidorId.HasValue)
            query = query.Where(a => a.RepartidorId == repartidorId);

        var total = await query.CountAsync();
        var asignaciones = await query
            .OrderByDescending(a => a.FechaAsignacion)
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();

        var response = new PaginatedResponse<AsignacionDto>
        {
            Data = asignaciones.Select(a => ToDto(a, a.Pedido!, a.Repartidor!)).ToList(),
            Page = page,
            Size = size,
            Total = total
        };

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AsignacionDto>> GetAsignacion(int id)
    {
        var asignacion = await _context.Asignaciones
            .Include(a => a.Pedido)
            .Include(a => a.Repartidor)
            .FirstOrDefaultAsync(a => a.Id == id);

        if (asignacion == null)
            return NotFound();

        return Ok(ToDto(asignacion, asignacion.Pedido!, asignacion.Repartidor!));
    }

    private static AsignacionDto ToDto(Asignacion asignacion, Pedido pedido, Usuario repartidor)
    {
        return new AsignacionDto
        {
            Id = asignacion.Id,
            PedidoId = asignacion.PedidoId,
            PedidoDescripcion = pedido.Descripcion,
            RepartidorId = asignacion.RepartidorId,
            RepartidorEmail = repartidor.Email,
            FechaAsignacion = asignacion.FechaAsignacion,
            FechaEntrega = asignacion.FechaEntrega
        };
    }
}

public class CreateAsignacionRequest
{
    public int PedidoId { get; set; }
    public int RepartidorId { get; set; }
}

public class AsignacionDto
{
    public int Id { get; set; }
    public int PedidoId { get; set; }
    public string PedidoDescripcion { get; set; } = string.Empty;
    public int RepartidorId { get; set; }
    public string RepartidorEmail { get; set; } = string.Empty;
    public DateTime FechaAsignacion { get; set; }
    public DateTime? FechaEntrega { get; set; }
}
