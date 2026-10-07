using DeliverySac.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliverySac.API.Data;

public class DeliverySacDbContext : DbContext
{
    public DeliverySacDbContext(DbContextOptions<DeliverySacDbContext> options) : base(options)
    {
    }

    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Cliente> Clientes => Set<Cliente>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
            entity.Property(e => e.PasswordHash).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Rol).IsRequired().HasMaxLength(50);
            entity.HasIndex(e => e.Email).IsUnique();
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nombre).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Direccion).IsRequired().HasMaxLength(500);
        });

        SeedUsuarios(modelBuilder);
        SeedClientes(modelBuilder);
    }

    private void SeedUsuarios(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>().HasData(
            new Usuario
            {
                Id = 1,
                Email = "admin@deliverysac.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("password123"),
                Rol = "Administrador"
            },
            new Usuario
            {
                Id = 2,
                Email = "repartidor@deliverysac.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("password123"),
                Rol = "Repartidor"
            },
            new Usuario
            {
                Id = 3,
                Email = "supervisor@deliverysac.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("password123"),
                Rol = "Supervisor"
            }
        );
    }

    private void SeedClientes(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>().HasData(
            new Cliente
            {
                Id = 1,
                Nombre = "Café Central",
                Direccion = "Calle 1 #100, Centro"
            },
            new Cliente
            {
                Id = 2,
                Nombre = "Restaurante El Buen Sabor",
                Direccion = "Avenida Principal 250, Zona Norte"
            },
            new Cliente
            {
                Id = 3,
                Nombre = "Farmacia Salud Plus",
                Direccion = "Calle Secundaria 75, Barrio Sur"
            }
        );
    }
}
