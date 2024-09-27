﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TurnoApi.Models;

public partial class TurnosDbContext : DbContext
{
    public TurnosDbContext()
    {
    }

    public TurnosDbContext(DbContextOptions<TurnosDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TDetallesTurno> TDetallesTurnos { get; set; }

    public virtual DbSet<TServicio> TServicios { get; set; }

    public virtual DbSet<TTurno> TTurnos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TDetallesTurno>(entity =>
        {
            entity.HasKey(e => new { e.IdTurno, e.IdServicio });

            entity.ToTable("T_DETALLES_TURNO");

            entity.Property(e => e.IdTurno).HasColumnName("id_turno");
            entity.Property(e => e.IdServicio).HasColumnName("id_servicio");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("observaciones");
        });

        modelBuilder.Entity<TServicio>(entity =>
        {
            entity.ToTable("T_SERVICIOS");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Costo).HasColumnName("costo");
            entity.Property(e => e.EnPromocion)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("enPromocion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TTurno>(entity =>
        {
            entity.ToTable("T_TURNOS");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cliente)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cliente");
            //Propiedades agregada por nosotros
           entity.Property(e=> e.FechaCancelacion)
            .HasColumnName("fecha_cancelacion");
            entity.Property(e => e.MotivoCancelacion)
            .HasColumnName("motivo_cancelacion");


            entity.Property(e => e.Fecha)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("fecha");
            entity.Property(e => e.Hora)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("hora");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}