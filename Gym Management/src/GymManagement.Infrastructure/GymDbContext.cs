using Microsoft.EntityFrameworkCore;
using GymManagement.Core;

namespace GymManagement.Infrastructure;

public class GymDbContext : DbContext
{
    public GymDbContext(DbContextOptions<GymDbContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<PagoMembresia> PagosMembresia { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.ToTable("clientes");
            entity.HasKey(e => e.Id_Usuario);

            entity.Property(e => e.Id_Usuario).HasColumnName("id_usuario").UseIdentityColumn();
            entity.Property(e => e.Nombre).HasColumnName("nombre").IsRequired();
            entity.Property(e => e.Apellidos).HasColumnName("apellidos").IsRequired();
            entity.Property(e => e.Telefono).HasColumnName("telefono");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fechanacimiento").HasColumnType("date");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecharegistro").HasColumnType("timestamp with time zone");
            entity.Property(e => e.Estado).HasColumnName("estado").IsRequired();
        });

        modelBuilder.Entity<PagoMembresia>(entity =>
        {
            entity.ToTable("pagosmembresia");
            entity.HasKey(e => e.Id_Mensualidad);

            entity.Property(e => e.Id_Mensualidad).HasColumnName("id_mensualidad").UseIdentityColumn();
            entity.Property(e => e.Id_Usuario).HasColumnName("id_usuario");
            entity.Property(e => e.TipoMembresia).HasColumnName("tipomembresia").IsRequired();
            entity.Property(e => e.Monto).HasColumnName("monto").HasColumnType("numeric");
            entity.Property(e => e.FechaPago).HasColumnName("fechapago").HasColumnType("timestamp with time zone");
            entity.Property(e => e.FechaInicio).HasColumnName("fechainicio").HasColumnType("date");
            entity.Property(e => e.FechaVencimiento).HasColumnName("fechavencimiento").HasColumnType("date");

            entity.HasOne(d => d.Cliente)
                  .WithMany(p => p.PagosMembresias)
                  .HasForeignKey(d => d.Id_Usuario)
                  .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
