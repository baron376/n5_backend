using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Security;
using web_api_permissions.Domain.Entities;

namespace web_api_permissions.Infrastructure
{
    public class PermissionsDbContext : DbContext
    {
        public PermissionsDbContext()
        {
        }

        public PermissionsDbContext(DbContextOptions<PermissionsDbContext> options)
        : base(options)
        {
        }

        public DbSet<Permiso> Permiso { get; set; }
        public DbSet<TipoPermiso> TipoPermiso { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Permiso Table Configuration
            modelBuilder.Entity<Permiso>()
                .HasKey(p => p.Id); 
            modelBuilder.Entity<Permiso>()
                .Property(p => p.NombreEmpleado)
                .IsRequired(); 
            modelBuilder.Entity<Permiso>()
                .Property(p => p.ApellidoEmpleado)
                .IsRequired();
            modelBuilder.Entity<Permiso>()
                .Property(p => p.TipoPermisoId)
                .IsRequired();
            modelBuilder.Entity<Permiso>()
                .Property(p => p.FechaPermiso)
                .IsRequired();

            // TipoPermiso Table Configuration 
            modelBuilder.Entity<TipoPermiso>()
                .HasKey(tp => tp.Id); 
            modelBuilder.Entity<TipoPermiso>()
                .Property(tp => tp.Descripcion)
                .IsRequired();

            // Relationship between the tables Permiso and TipoPermiso
            modelBuilder.Entity<Permiso>()
                .HasOne(p => p.TipoPermiso)
                .WithMany()
                .HasForeignKey(p => p.TipoPermisoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
