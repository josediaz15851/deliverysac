using DeliverySac.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliverySac.API.Data;

public class DeliverySacDbContext : DbContext
{
    public DeliverySacDbContext(DbContextOptions<DeliverySacDbContext> options) : base(options)
    {
    }

    public DbSet<Usuario> Usuarios => Set<Usuario>();

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

        SeedUsuarios(modelBuilder);
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
}
