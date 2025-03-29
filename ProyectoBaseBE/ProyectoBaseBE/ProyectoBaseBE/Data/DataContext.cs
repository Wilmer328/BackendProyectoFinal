using Microsoft.EntityFrameworkCore;
using ProyectoBaseBE.Models;
namespace ProyectoBaseBE.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Fiestas> Fiestas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Fiestas>().ToTable("fiestas");

        modelBuilder.Entity<Fiestas>().Property(f => f.Nombre).HasColumnName("nombre");
        modelBuilder.Entity<Fiestas>().Property(f => f.Invitados).HasColumnName("invitados");
        modelBuilder.Entity<Fiestas>().Property(f => f.Comida).HasColumnName("comida");
        modelBuilder.Entity<Fiestas>().Property(f => f.Decoracion).HasColumnName("decoracion");
        modelBuilder.Entity<Fiestas>().Property(f => f.Fecha).HasColumnName("fecha");

    }

}

    