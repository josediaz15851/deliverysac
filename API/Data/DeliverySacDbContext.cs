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
    }
}
