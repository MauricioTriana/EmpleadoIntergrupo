using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Bussiness.EntityFramework
{
    public partial class PruebaIntergrupoContext : DbContext
    {
        public PruebaIntergrupoContext()
        {
        }

        public PruebaIntergrupoContext(DbContextOptions<PruebaIntergrupoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empleado> Empleado { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-7G6C4AT3\\SQLEXPRESS;Initial Catalog=PruebaIntergrupo;Persist Security Info=False;User ID=ctriana;Password=Moon2021;Encrypt=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado);

                entity.Property(e => e.IdEmpleado)
                    .HasColumnName("Id_Empleado");

                entity.Property(e => e.ApellidoEmpleado)
                    .IsRequired()
                    .HasColumnName("Apellido_Empleado")
                    .HasMaxLength(200);

                entity.Property(e => e.Cargo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DocumentoIdentidad)
                    .IsRequired()
                    .HasColumnName("Documento_Identidad")
                    .HasMaxLength(50);

                entity.Property(e => e.NombreEmpleado)
                    .IsRequired()
                    .HasColumnName("Nombre_Empleado")
                    .HasMaxLength(200);

                entity.Property(e => e.contrasena)
                  .IsRequired()
                  .HasMaxLength(20);
            });
        }
    }
}
