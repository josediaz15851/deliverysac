using DeliverySac.API.Data;
using DeliverySac.API.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DeliverySac.API.Services;

public class AuthService
{
    private readonly DeliverySacDbContext _context;
    private readonly IConfiguration _config;

    public AuthService(DeliverySacDbContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    public async Task<string?> LoginAsync(string email, string password)
    {
        var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == email);

        if (usuario == null || !BCrypt.Net.BCrypt.Verify(password, usuario.PasswordHash))
            return null;

        return GenerateJwt(usuario);
    }

    private string GenerateJwt(Usuario usuario)
    {
        var jwtSecret = _config["JwtSettings:Secret"] ?? throw new InvalidOperationException("JwtSettings:Secret no configurado");
        var jwtIssuer = _config["JwtSettings:Issuer"] ?? "DeliverySac";
        var jwtAudience = _config["JwtSettings:Audience"] ?? "DeliverySacUsers";

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new Claim(ClaimTypes.Email, usuario.Email),
            new Claim(ClaimTypes.Role, usuario.Rol)
        };

        var token = new JwtSecurityToken(
            issuer: jwtIssuer,
            audience: jwtAudience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(8),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
