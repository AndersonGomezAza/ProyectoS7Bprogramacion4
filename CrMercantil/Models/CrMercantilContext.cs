using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CrMercantil.Models;

public partial class CrMercantilContext : DbContext
{
    public CrMercantilContext()
    {
    }

    public CrMercantilContext(DbContextOptions<CrMercantilContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ArregloLocativo> ArregloLocativos { get; set; }

    public virtual DbSet<Arrendatario> Arrendatarios { get; set; }

    public virtual DbSet<ContratoArriendo> ContratoArriendos { get; set; }

    public virtual DbSet<ContratoInmueble> ContratoInmuebles { get; set; }

    public virtual DbSet<Inmueble> Inmuebles { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Propietario> Propietarios { get; set; }

    public virtual DbSet<Proyecto> Proyectos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-HNG3HQ1\\SQLEXPRESS; Database=cr_mercantil_bbdd; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ArregloLocativo>(entity =>
        {
            entity.HasKey(e => e.IdLocativaArreglo).HasName("PK__ArregloL__B2E00EC9F1E534E9");

            entity.ToTable("ArregloLocativo");

            entity.Property(e => e.IdLocativaArreglo)
                .ValueGeneratedNever()
                .HasColumnName("id_locativa_arreglo");
            entity.Property(e => e.EstadoArreglo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("estado_arreglo");
            entity.Property(e => e.FechaFinalizacionArreglo)
                .HasColumnType("date")
                .HasColumnName("fecha_finalizacion_arreglo");
            entity.Property(e => e.FechaInicioArreglo)
                .HasColumnType("date")
                .HasColumnName("fecha_inicio_arreglo");
            entity.Property(e => e.ObservacionesArreglo)
                .HasColumnType("text")
                .HasColumnName("observaciones_arreglo");
        });

        modelBuilder.Entity<Arrendatario>(entity =>
        {
            entity.HasKey(e => e.CedulaArrendatario).HasName("PK__Arrendat__DC4CD88EFEFA5B89");

            entity.ToTable("Arrendatario");

            entity.HasIndex(e => e.CorreoArrendatario, "UQ_correo_arrendatario").IsUnique();

            entity.Property(e => e.CedulaArrendatario)
                .ValueGeneratedNever()
                .HasColumnName("cedula_arrendatario");
            entity.Property(e => e.ApellidoArrendatario)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("apellido_arrendatario");
            entity.Property(e => e.CorreoArrendatario)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("correo_arrendatario");
            entity.Property(e => e.NombreArrendatario)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nombre_arrendatario");
            entity.Property(e => e.TelefonoArrendatario).HasColumnName("telefono_arrendatario");
        });

        modelBuilder.Entity<ContratoArriendo>(entity =>
        {
            entity.HasKey(e => e.IdContrato).HasName("PK__Contrato__FF5F2A56F4212CAC");

            entity.ToTable("ContratoArriendo");

            entity.Property(e => e.IdContrato)
                .ValueGeneratedNever()
                .HasColumnName("id_contrato");
            entity.Property(e => e.CedulaArrendatarioContrato).HasColumnName("cedula_arrendatario_contrato");
            entity.Property(e => e.FechaInicioContrato)
                .HasColumnType("date")
                .HasColumnName("fecha_inicio_contrato");
            entity.Property(e => e.RcPagosContrato).HasColumnName("rc_pagos_contrato");
            entity.Property(e => e.ValorAdministracionContrato)
                .HasColumnType("decimal(14, 4)")
                .HasColumnName("valor_administracion_contrato");
            entity.Property(e => e.ValorCanonContrato)
                .HasColumnType("decimal(14, 4)")
                .HasColumnName("valor_canon_contrato");

            entity.HasOne(d => d.CedulaArrendatarioContratoNavigation).WithMany(p => p.ContratoArriendos)
                .HasForeignKey(d => d.CedulaArrendatarioContrato)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pk_contrato_arrendatario");

            entity.HasOne(d => d.RcPagosContratoNavigation).WithMany(p => p.ContratoArriendos)
                .HasForeignKey(d => d.RcPagosContrato)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pk_contrato_pagos");
        });

        modelBuilder.Entity<ContratoInmueble>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ContratoInmueble");

            entity.Property(e => e.IdContrato).HasColumnName("id_contrato");
            entity.Property(e => e.MatriculaInmobiliariaInmueble)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("matricula_inmobiliaria_inmueble");

            entity.HasOne(d => d.IdContratoNavigation).WithMany()
                .HasForeignKey(d => d.IdContrato)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pk_contrato_inmueble_contrato_arriendo");

            entity.HasOne(d => d.MatriculaInmobiliariaInmuebleNavigation).WithMany()
                .HasForeignKey(d => d.MatriculaInmobiliariaInmueble)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pk_contrato_inmueble_inmueble");
        });

        modelBuilder.Entity<Inmueble>(entity =>
        {
            entity.HasKey(e => e.MatriculaInmobiliariaInmueble).HasName("PK__Inmueble__AB1540A0F0FB3B98");

            entity.ToTable("Inmueble");

            entity.Property(e => e.MatriculaInmobiliariaInmueble)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("matricula_inmobiliaria_inmueble");
            entity.Property(e => e.AlcobasInmueble).HasColumnName("alcobas_inmueble");
            entity.Property(e => e.AreaConstruidaInmueble)
                .HasColumnType("decimal(14, 4)")
                .HasColumnName("area_construida_inmueble");
            entity.Property(e => e.AreaPrivadaInmueble)
                .HasColumnType("decimal(14, 4)")
                .HasColumnName("area_privada_inmueble");
            entity.Property(e => e.BañosInmueble).HasColumnName("baños_inmueble");
            entity.Property(e => e.CedulaPropietarioInmueble).HasColumnName("cedula_propietario_inmueble");
            entity.Property(e => e.ChipInmueble)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("chip_inmueble");
            entity.Property(e => e.IdLocativaInmueble).HasColumnName("id_locativa_inmueble");
            entity.Property(e => e.MatriculaInmobiliariaProyectoInmueble).HasColumnName("matricula_inmobiliaria_proyecto_inmueble");
            entity.Property(e => e.NomenclaruraInmueble)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("nomenclarura_inmueble");
            entity.Property(e => e.NumeroEscrituraInmueble)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("numero_escritura_inmueble");
            entity.Property(e => e.TipoInmueble)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("tipo_inmueble");
            entity.Property(e => e.VehiculoInmueble).HasColumnName("vehiculo_inmueble");

            entity.HasOne(d => d.CedulaPropietarioInmuebleNavigation).WithMany(p => p.Inmuebles)
                .HasForeignKey(d => d.CedulaPropietarioInmueble)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pk_inmueble_propietario");

            entity.HasOne(d => d.IdLocativaInmuebleNavigation).WithMany(p => p.Inmuebles)
                .HasForeignKey(d => d.IdLocativaInmueble)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pk_inmueble_arreglo");

            entity.HasOne(d => d.MatriculaInmobiliariaProyectoInmuebleNavigation).WithMany(p => p.Inmuebles)
                .HasForeignKey(d => d.MatriculaInmobiliariaProyectoInmueble)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pk_inmueble_proyecto");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.RcPagos).HasName("PK__Pagos__58807614E1623F63");

            entity.Property(e => e.RcPagos).HasColumnName("rc_pagos");
            entity.Property(e => e.AbonoAdministracionPagos)
                .HasColumnType("decimal(14, 4)")
                .HasColumnName("abono_administracion_pagos");
            entity.Property(e => e.FacturaPagos).HasColumnName("factura_pagos");
            entity.Property(e => e.FechaAbonoCanonPagos)
                .HasColumnType("date")
                .HasColumnName("fecha_abono_canon_pagos");
            entity.Property(e => e.FechaPagos)
                .HasColumnType("date")
                .HasColumnName("fecha_pagos");
            entity.Property(e => e.InteresPagos)
                .HasColumnType("decimal(14, 4)")
                .HasColumnName("interes_pagos");
            entity.Property(e => e.TasaInteresPagos)
                .HasColumnType("decimal(14, 4)")
                .HasColumnName("tasa_interes_pagos");
        });

        modelBuilder.Entity<Propietario>(entity =>
        {
            entity.HasKey(e => e.CedulaPropietario).HasName("PK__Propieta__955E849F749D9B67");

            entity.ToTable("Propietario");

            entity.HasIndex(e => e.CorreoPropietario, "UQ_correo_propietario").IsUnique();

            entity.Property(e => e.CedulaPropietario)
                .ValueGeneratedNever()
                .HasColumnName("cedula_propietario");
            entity.Property(e => e.ApellidoPropietario)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("apellido_propietario");
            entity.Property(e => e.CorreoPropietario)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("correo_propietario");
            entity.Property(e => e.CuentaBancariaPropietario).HasColumnName("cuenta_bancaria_propietario");
            entity.Property(e => e.NombreBancoPropietario)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre_banco_propietario");
            entity.Property(e => e.NombrePropietario)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nombre_propietario");
            entity.Property(e => e.TelefonoPropietario).HasColumnName("telefono_propietario");
            entity.Property(e => e.TipoCuentaPropietario)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("tipo_cuenta_propietario");
        });

        modelBuilder.Entity<Proyecto>(entity =>
        {
            entity.HasKey(e => e.MatriculaInmobiliariaProyecto).HasName("PK__Proyecto__8449E8E1A22850F9");

            entity.ToTable("Proyecto");

            entity.HasIndex(e => e.CorreoAdministradorProyecto, "UQ_correo_administrador_proyecto").IsUnique();

            entity.Property(e => e.MatriculaInmobiliariaProyecto)
                .ValueGeneratedNever()
                .HasColumnName("matricula_inmobiliaria_proyecto");
            entity.Property(e => e.AdministradorProyecto)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("administrador_proyecto");
            entity.Property(e => e.CorreoAdministradorProyecto)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("correo_administrador_proyecto");
            entity.Property(e => e.DireccionProyecto)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("direccion_proyecto");
            entity.Property(e => e.EscrituraReglamentoProyecto)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("escritura_reglamento_proyecto");
            entity.Property(e => e.EstratoProyecto).HasColumnName("estrato_proyecto");
            entity.Property(e => e.NombreProyecto)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre_proyecto");
            entity.Property(e => e.TelefonoAdministradorProyecto)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("telefono_administrador_proyecto");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
