using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Partida.Data;
using Partida.Modelos;

#nullable disable

namespace Partida.ModelosNuevos
{
    public partial class EjercicioEvaluacionContext : IdentityDbContext<AplicationUser, UserRoles, string>
    {
        public EjercicioEvaluacionContext(DbContextOptions<EjercicioEvaluacionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TipoVehiculo> TipoVehiculos { get; set; }
        public virtual DbSet<Vehiculo> Vehiculos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TipoVehiculo>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__TipoVehi__06370DAD4F6695D2");

                entity.ToTable("TipoVehiculo");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoVehiculoNavigation)
                    .WithMany(p => p.TipoVehiculos)
                    .HasForeignKey(d => d.CodigoVehiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Vehicuo");
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__Vehiculo__06370DAD2CC81A0F");

                entity.ToTable("Vehiculo");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}
