using DeliverySac.API.Data;
using DeliverySac.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeliverySac.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ClienteController : ControllerBase
{
    private readonly DeliverySacDbContext _context;

    public ClienteController(DeliverySacDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<ClienteDto>> CreateCliente([FromBody] CreateClienteRequest request)
    {
        if (string.IsNullOrEmpty(request.Nombre) || string.IsNullOrEmpty(request.Direccion))
            return BadRequest("Nombre y dirección son requeridos");

        var cliente = new Cliente
        {
            Nombre = request.Nombre,
            Direccion = request.Direccion
        };

        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, ToDto(cliente));
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResponse<ClienteDto>>> GetClientes([FromQuery] int page = 1, [FromQuery] int size = 10)
    {
        if (page < 1 || size < 1)
            return BadRequest("page y size deben ser mayores que 0");

        var total = await _context.Clientes.CountAsync();
        var clientes = await _context.Clientes
            .OrderBy(c => c.Id)
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();

        var response = new PaginatedResponse<ClienteDto>
        {
            Data = clientes.Select(ToDto).ToList(),
            Page = page,
            Size = size,
            Total = total
        };

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ClienteDto>> GetCliente(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente == null)
            return NotFound();

        return Ok(ToDto(cliente));
    }

    private static ClienteDto ToDto(Cliente cliente)
    {
        return new ClienteDto
        {
            Id = cliente.Id,
            Nombre = cliente.Nombre,
            Direccion = cliente.Direccion
        };
    }
}

public class CreateClienteRequest
{
    public string Nombre { get; set; } = string.Empty;
    public string Direccion { get; set; } = string.Empty;
}

public class ClienteDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Direccion { get; set; } = string.Empty;
}

public class PaginatedResponse<T>
{
    public List<T> Data { get; set; } = [];
    public int Page { get; set; }
    public int Size { get; set; }
    public int Total { get; set; }
}
