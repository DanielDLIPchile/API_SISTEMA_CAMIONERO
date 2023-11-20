using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Camiones.Models;

public partial class CamionesContext : DbContext
{
    public CamionesContext()
    {
    }

    public CamionesContext(DbContextOptions<CamionesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Camione> Camiones { get; set; }

    public virtual DbSet<Camionero> Camioneros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;Database=Camiones;Uid=root;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Camione>(entity =>
        {
            entity.HasKey(e => e.Patente).HasName("PRIMARY");

            entity.ToTable("camiones");

            entity.Property(e => e.Patente).HasMaxLength(20);
            entity.Property(e => e.GpsCc)
                .HasMaxLength(2)
                .HasDefaultValueSql("'000'")
                .IsFixedLength()
                .HasColumnName("GPS_CC");
            entity.Property(e => e.IdCamionero)
                .HasDefaultValueSql("'000'")
                .HasColumnType("int(11)");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .HasDefaultValueSql("'.'");
            entity.Property(e => e.PesoCamion)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)");
            entity.Property(e => e.PesoCarga)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)");
            entity.Property(e => e.TipoCamion)
                .HasMaxLength(50)
                .HasDefaultValueSql("'.'");
        });

        modelBuilder.Entity<Camionero>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("camioneros");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .HasDefaultValueSql("'.'");
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .HasDefaultValueSql("'.'");
            entity.Property(e => e.Edad)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)");
            entity.Property(e => e.EstadoCivil)
                .HasMaxLength(20)
                .HasDefaultValueSql("'.'");
            entity.Property(e => e.FechaNacimiento)
                .HasDefaultValueSql("'0/0/0'")
                .HasColumnType("date");
            entity.Property(e => e.Genero)
                .HasMaxLength(10)
                .HasDefaultValueSql("'.'");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasDefaultValueSql("'.'");
            entity.Property(e => e.NumeroHijos)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
