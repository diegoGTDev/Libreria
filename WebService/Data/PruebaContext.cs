using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebService.Data.Models;

namespace WebService.Data
{
    public partial class PruebaContext : DbContext
    {
        public PruebaContext()
        {
        }

        public PruebaContext(DbContextOptions<PruebaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autors { get; set; } = null!;
        public virtual DbSet<Estudiante> Estudiantes { get; set; } = null!;
        public virtual DbSet<Libro> Libros { get; set; } = null!;
        public virtual DbSet<Prestamo> Prestamos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-17OBIDL\\SQLEXPRESS;Database=Prueba;Trusted_Connection=true;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>(entity =>
            {
                entity.HasKey(e => e.IdAutor)
                    .HasName("PK__Autor__DD33B0313C9F800C");

                entity.ToTable("Autor");

                entity.Property(e => e.Nacionalidad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasMany(d => d.IdLibros)
                    .WithMany(p => p.IdAutors)
                    .UsingEntity<Dictionary<string, object>>(
                        "LibAut",
                        l => l.HasOne<Libro>().WithMany().HasForeignKey("IdLibro").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__LibAut__IdLibro__4D94879B"),
                        r => r.HasOne<Autor>().WithMany().HasForeignKey("IdAutor").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__LibAut__IdAutor__4E88ABD4"),
                        j =>
                        {
                            j.HasKey("IdAutor", "IdLibro").HasName("PK__LibAut__1ED304AB1F340032");

                            j.ToTable("LibAut");
                        });
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.IdLector)
                    .HasName("PK__Estudian__9644AB8B5BCF0886");

                entity.ToTable("Estudiante");

                entity.Property(e => e.Carrera)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Ci)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CI");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.IdLibro)
                    .HasName("PK__Libro__3E0B49ADFDEF28CD");

                entity.ToTable("Libro");

                entity.Property(e => e.Area)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Editorial)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Prestamo>(entity =>
            {
                entity.HasKey(e => new { e.FechaPrestamo, e.IdLibro, e.IdLector })
                    .HasName("PK__Prestamo__A9D7554FC7A95047");

                entity.ToTable("Prestamo");

                entity.Property(e => e.FechaPrestamo).HasColumnType("date");

                entity.Property(e => e.Devuelto).HasColumnName("DEVUELTO");

                entity.Property(e => e.FechaDevolucion).HasColumnType("date");

                entity.HasOne(d => d.IdLectorNavigation)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.IdLector)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Prestamo__IdLect__534D60F1");

                entity.HasOne(d => d.IdLibroNavigation)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.IdLibro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Prestamo__IdLibr__5441852A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
