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
    public DbSet<Pedido> Pedidos => Set<Pedido>();
    public DbSet<Asignacion> Asignaciones => Set<Asignacion>();

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

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.ClienteId).IsRequired();
            entity.Property(e => e.Descripcion).IsRequired().HasMaxLength(500);
            entity.Property(e => e.Monto).HasPrecision(18, 2);
            entity.Property(e => e.Estado).IsRequired();
            entity.Property(e => e.FechaCreacion).IsRequired();
            entity.Property(e => e.FechaActualizacion).IsRequired();
            entity.HasOne(e => e.Cliente).WithMany().HasForeignKey(e => e.ClienteId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Asignacion>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.PedidoId).IsRequired();
            entity.Property(e => e.RepartidorId).IsRequired();
            entity.Property(e => e.FechaAsignacion).IsRequired();
            entity.HasOne(e => e.Pedido).WithMany().HasForeignKey(e => e.PedidoId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.Repartidor).WithMany().HasForeignKey(e => e.RepartidorId).OnDelete(DeleteBehavior.Restrict);
        });

        SeedUsuarios(modelBuilder);
        SeedClientes(modelBuilder);
        SeedPedidos(modelBuilder);
        SeedAsignaciones(modelBuilder);
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

    private void SeedPedidos(ModelBuilder modelBuilder)
    {
        var now = DateTime.UtcNow;
        modelBuilder.Entity<Pedido>().HasData(
            new Pedido
            {
                Id = 1,
                ClienteId = 1,
                Descripcion = "2 cafés cortados + 1 medialunas",
                Monto = 450.00m,
                Estado = EstadoPedido.PENDIENTE,
                FechaCreacion = now,
                FechaActualizacion = now
            },
            new Pedido
            {
                Id = 2,
                ClienteId = 2,
                Descripcion = "Menú completo para 4 personas",
                Monto = 2500.00m,
                Estado = EstadoPedido.ASIGNADO,
                FechaCreacion = now.AddHours(-2),
                FechaActualizacion = now.AddHours(-1)
            },
            new Pedido
            {
                Id = 3,
                ClienteId = 3,
                Descripcion = "Vitaminas y suplementos varios",
                Monto = 1800.50m,
                Estado = EstadoPedido.EN_RUTA,
                FechaCreacion = now.AddHours(-5),
                FechaActualizacion = now.AddMinutes(-30)
            }
        );
    }

    private void SeedAsignaciones(ModelBuilder modelBuilder)
    {
        var now = DateTime.UtcNow;
        modelBuilder.Entity<Asignacion>().HasData(
            new Asignacion
            {
                Id = 1,
                PedidoId = 2,
                RepartidorId = 2,
                FechaAsignacion = now.AddHours(-1),
                FechaEntrega = null
            },
            new Asignacion
            {
                Id = 2,
                PedidoId = 3,
                RepartidorId = 2,
                FechaAsignacion = now.AddHours(-5),
                FechaEntrega = null
            }
        );
    }
}
