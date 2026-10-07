using DeliverySac.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeliverySac.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            return BadRequest("Email y contraseña son requeridos");

        var token = await _authService.LoginAsync(request.Email, request.Password);

        if (token == null)
            return Unauthorized("Credenciales inválidas");

        return Ok(new { token });
    }
}

public class LoginRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
