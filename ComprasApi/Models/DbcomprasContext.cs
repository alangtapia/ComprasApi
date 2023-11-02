using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ComprasApi.Models;

public partial class DbcomprasContext : DbContext
{
    public DbcomprasContext()
    {
    }

    public DbcomprasContext(DbContextOptions<DbcomprasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Articulo> Articulos { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<OrdenesDeCompra> OrdenesDeCompras { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<UnidadesDeMedidum> UnidadesDeMedida { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {  }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Articulo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Articulo__3213E83FEBC6C0EF");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Existencia).HasColumnName("existencia");
            entity.Property(e => e.Marca)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("marca");
            entity.Property(e => e.UnidadDeMedida).HasColumnName("unidad_de_medida");

            entity.HasOne(d => d.oUnidad).WithMany(p => p.Articulos)
                .HasForeignKey(d => d.UnidadDeMedida)
                .HasConstraintName("FK__Articulos__unida__48CFD27E");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departam__3213E83FB82B6A03");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<OrdenesDeCompra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrdenesD__3213E83FD59A918B");

            entity.ToTable("OrdenesDeCompra");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Articulo).HasColumnName("articulo");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.CostoUnitario)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("costo_unitario");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaDeOrden)
                .HasColumnType("date")
                .HasColumnName("fecha_de_orden");
            entity.Property(e => e.UnidadDeMedida).HasColumnName("unidad_de_medida");

            entity.HasOne(d => d.oArticulo).WithMany(p => p.OrdenesDeCompras)
                .HasForeignKey(d => d.Articulo)
                .HasConstraintName("FK__OrdenesDe__artic__4BAC3F29");

            entity.HasOne(d => d.oUnidad).WithMany(p => p.OrdenesDeCompras)
                .HasForeignKey(d => d.UnidadDeMedida)
                .HasConstraintName("FK__OrdenesDe__unida__4CA06362");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proveedo__3213E83F4640898F");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CedulaRnc)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cedula_rnc");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.NombreComercial)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre_comercial");
        });

        modelBuilder.Entity<UnidadesDeMedidum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Unidades__3213E83F612180CA");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
