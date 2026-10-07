using DeliverySac.API.Data;
using DeliverySac.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DeliverySac.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CambioEstadoController : ControllerBase
{
    private readonly DeliverySacDbContext _context;

    public CambioEstadoController(DeliverySacDbContext context)
    {
        _context = context;
    }

    [HttpPost("cambiar")]
    public async Task<ActionResult<CambioEstadoDto>> CambiarEstado([FromBody] CambiarEstadoRequest request)
    {
        var pedido = await _context.Pedidos.FindAsync(request.PedidoId);
        if (pedido == null)
            return BadRequest("Pedido no existe");

        var usuarioIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!int.TryParse(usuarioIdClaim, out int usuarioId))
            return Unauthorized("No se puede determinar el usuario");

        var usuario = await _context.Usuarios.FindAsync(usuarioId);
        if (usuario == null)
            return Unauthorized("Usuario no válido");

        var estadoAnterior = pedido.Estado;
        var estadoNuevo = Enum.Parse<EstadoPedido>(request.EstadoNuevo);

        if (!EsTransicionValida(estadoAnterior, estadoNuevo))
            return BadRequest($"No se puede pasar de {estadoAnterior} a {estadoNuevo}");

        var cambio = new CambioEstado
        {
            PedidoId = request.PedidoId,
            UsuarioId = usuarioId,
            EstadoAnterior = estadoAnterior,
            EstadoNuevo = estadoNuevo,
            Fecha = DateTime.UtcNow
        };

        pedido.Estado = estadoNuevo;
        pedido.FechaActualizacion = DateTime.UtcNow;

        _context.CambiosEstado.Add(cambio);
        _context.Pedidos.Update(pedido);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCambio), new { id = cambio.Id }, ToDto(cambio, usuario));
    }

    [HttpGet("{pedidoId}")]
    public async Task<ActionResult<List<CambioEstadoDto>>> GetHistorial(int pedidoId)
    {
        var cambios = await _context.CambiosEstado
            .Include(c => c.Usuario)
            .Where(c => c.PedidoId == pedidoId)
            .OrderByDescending(c => c.Fecha)
            .ToListAsync();

        if (!cambios.Any())
            return NotFound($"No hay historial para pedido {pedidoId}");

        return Ok(cambios.Select(c => ToDto(c, c.Usuario!)).ToList());
    }

    [HttpGet("detalle/{id}")]
    public async Task<ActionResult<CambioEstadoDto>> GetCambio(int id)
    {
        var cambio = await _context.CambiosEstado
            .Include(c => c.Usuario)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (cambio == null)
            return NotFound();

        return Ok(ToDto(cambio, cambio.Usuario!));
    }

    private static bool EsTransicionValida(EstadoPedido actual, EstadoPedido nuevo)
    {
        return (actual, nuevo) switch
        {
            (EstadoPedido.PENDIENTE, EstadoPedido.ASIGNADO) => true,
            (EstadoPedido.ASIGNADO, EstadoPedido.EN_RUTA) => true,
            (EstadoPedido.EN_RUTA, EstadoPedido.ENTREGADO) => true,
            (EstadoPedido.EN_RUTA, EstadoPedido.NO_ENTREGADO) => true,
            (EstadoPedido.EN_RUTA, EstadoPedido.REPROGRAMADO) => true,
            (EstadoPedido.NO_ENTREGADO, EstadoPedido.REPROGRAMADO) => true,
            (EstadoPedido.REPROGRAMADO, EstadoPedido.EN_RUTA) => true,
            _ => false
        };
    }

    private static CambioEstadoDto ToDto(CambioEstado cambio, Usuario usuario)
    {
        return new CambioEstadoDto
        {
            Id = cambio.Id,
            PedidoId = cambio.PedidoId,
            UsuarioEmail = usuario.Email,
            EstadoAnterior = cambio.EstadoAnterior.ToString(),
            EstadoNuevo = cambio.EstadoNuevo.ToString(),
            Fecha = cambio.Fecha
        };
    }
}

public class CambiarEstadoRequest
{
    public int PedidoId { get; set; }
    public string EstadoNuevo { get; set; } = string.Empty;
}

public class CambioEstadoDto
{
    public int Id { get; set; }
    public int PedidoId { get; set; }
    public string UsuarioEmail { get; set; } = string.Empty;
    public string EstadoAnterior { get; set; } = string.Empty;
    public string EstadoNuevo { get; set; } = string.Empty;
    public DateTime Fecha { get; set; }
}
