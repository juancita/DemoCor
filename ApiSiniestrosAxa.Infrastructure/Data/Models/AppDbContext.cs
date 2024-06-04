using System;
using System.Collections.Generic;
using ApiSiniestrosAxa.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiSiniestrosAxa.Infrastructure.Data.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Analista> Analistas { get; set; }

    public virtual DbSet<ArchivosAdjunto> ArchivosAdjuntos { get; set; }

    public virtual DbSet<ArchivosSolicitado> ArchivosSolicitados { get; set; }

    public virtual DbSet<Ciudade> Ciudades { get; set; }

    public virtual DbSet<Cobertura> Coberturas { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<EstadoSiniestro> EstadoSiniestros { get; set; }

    public virtual DbSet<HistorialArchivosCarga> HistorialArchivosCargas { get; set; }

    public virtual DbSet<ListaArchivo> ListaArchivos { get; set; }

    public virtual DbSet<ListaArchivosDetalle> ListaArchivosDetalles { get; set; }

    public virtual DbSet<MovilidadDeSiniestro> MovilidadDeSiniestros { get; set; }

    public virtual DbSet<Movimiento> Movimientos { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Ramo> Ramos { get; set; }

    public virtual DbSet<Siniestro> Siniestros { get; set; }

    public virtual DbSet<TipoCertificacion> TipoCertificacions { get; set; }

    public virtual DbSet<TipoConsultum> TipoConsulta { get; set; }

    public virtual DbSet<TiposDocumento> TiposDocumentos { get; set; }

    public virtual DbSet<TiposReclamacion> TiposReclamacions { get; set; }

    public virtual DbSet<TiposReclamante> TiposReclamantes { get; set; }

    public virtual DbSet<TiposUsuario> TiposUsuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=192.168.115.24\\pruebas2016,51382;Database=Siniestros;User Id=usrSupermercado;Password=usrSupermercadoDES;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Analista>(entity =>
        {
            entity.HasKey(e => e.IdAnalista);

            entity.ToTable("Analistas", "siniestros");

            entity.Property(e => e.Correo)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Creado).HasColumnType("datetime");
            entity.Property(e => e.CreadoPor)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Modificado).HasColumnType("datetime");
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ArchivosAdjunto>(entity =>
        {
            entity.HasKey(e => e.IdArchivoAdjunto);

            entity.ToTable("ArchivosAdjuntos", "siniestros");

            entity.Property(e => e.Creado).HasColumnType("datetime");
            entity.Property(e => e.CreadoPor)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Modificado).HasColumnType("datetime");
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.IdSiniestroNavigation).WithMany(p => p.ArchivosAdjuntos)
                .HasForeignKey(d => d.IdSiniestro)
                .HasConstraintName("FK_ArchivosAdjuntosIdSiniestro");
        });

        modelBuilder.Entity<ArchivosSolicitado>(entity =>
        {
            entity.HasKey(e => e.IdArchivoSolicitado);

            entity.ToTable("ArchivosSolicitado", "siniestros");

            entity.Property(e => e.Creado).HasColumnType("datetime");
            entity.Property(e => e.CreadoPor)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FormularioPdf)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FormularioPDF");
            entity.Property(e => e.Modificado).HasColumnType("datetime");
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ciudade>(entity =>
        {
            entity.HasKey(e => e.IdCiudad);

            entity.ToTable("Ciudades", "siniestros");

            entity.Property(e => e.Creado).HasColumnType("datetime");
            entity.Property(e => e.CreadoPor)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Divipola)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Modificado).HasColumnType("datetime");
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Ciudades)
                .HasForeignKey(d => d.IdDepartamento)
                .HasConstraintName("FK_CiudadesIdDepartamento");
        });

        modelBuilder.Entity<Cobertura>(entity =>
        {
            entity.HasKey(e => e.IdCobertura);

            entity.ToTable("Coberturas", "siniestros");

            entity.Property(e => e.Creado).HasColumnType("datetime");
            entity.Property(e => e.CreadoPor)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Modificado).HasColumnType("datetime");
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRamoNavigation).WithMany(p => p.Coberturas)
                .HasForeignKey(d => d.IdRamo)
                .HasConstraintName("FK_CoberturasidRamo");

            entity.HasOne(d => d.IdTlpoReclamacionNavigation).WithMany(p => p.Coberturas)
                .HasForeignKey(d => d.IdTlpoReclamacion)
                .HasConstraintName("FK_CoberturasidTlpoReclamacion");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento);

            entity.ToTable("Departamentos", "siniestros");

            entity.Property(e => e.Creado).HasColumnType("datetime");
            entity.Property(e => e.CreadoPor)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Divipola)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Modificado).HasColumnType("datetime");
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EstadoSiniestro>(entity =>
        {
            entity.HasKey(e => e.IdEstado);

            entity.ToTable("EstadoSiniestro", "siniestros");

            entity.Property(e => e.Creado).HasColumnType("datetime");
            entity.Property(e => e.CreadoPor)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.EstadoSiniestro1)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("EstadoSiniestro");
            entity.Property(e => e.Modificado).HasColumnType("datetime");
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HistorialArchivosCarga>(entity =>
        {
            entity.HasKey(e => e.NumeroSiniestro).HasName("PK__Historia__56B8DA5DA8E3D51D");

            entity.ToTable("HistorialArchivosCarga", "siniestros");

            entity.Property(e => e.NumeroSiniestro)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<ListaArchivo>(entity =>
        {
            entity.HasKey(e => e.IdListaArchivo);

            entity.ToTable("ListaArchivos", "siniestros");

            entity.Property(e => e.Creado).HasColumnType("datetime");
            entity.Property(e => e.CreadoPor)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Modificado).HasColumnType("datetime");
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCoberturaNavigation).WithMany(p => p.ListaArchivos)
                .HasForeignKey(d => d.IdCobertura)
                .HasConstraintName("FK_ListaArchivosIdCobertura");

            entity.HasOne(d => d.IdRamoNavigation).WithMany(p => p.ListaArchivos)
                .HasForeignKey(d => d.IdRamo)
                .HasConstraintName("FK_ListaArchivosIdRamo");

            entity.HasOne(d => d.IdTipoReclamacionNavigation).WithMany(p => p.ListaArchivos)
                .HasForeignKey(d => d.IdTipoReclamacion)
                .HasConstraintName("FK_ListaArchivosIdTipoReclamacion");
        });

        modelBuilder.Entity<ListaArchivosDetalle>(entity =>
        {
            entity.HasKey(e => e.IdListaArchivoDetalle);

            entity.ToTable("ListaArchivosDetalle", "siniestros");

            entity.Property(e => e.Creado).HasColumnType("datetime");
            entity.Property(e => e.CreadoPor)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Modificado).HasColumnType("datetime");
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.IdArchivoSolicitadoNavigation).WithMany(p => p.ListaArchivosDetalles)
                .HasForeignKey(d => d.IdArchivoSolicitado)
                .HasConstraintName("FK_ListaArchivosDetalleIdArchivoSolicitado");

            entity.HasOne(d => d.IdListaArchivoNavigation).WithMany(p => p.ListaArchivosDetalles)
                .HasForeignKey(d => d.IdListaArchivo)
                .HasConstraintName("FK_ListaArchivosDetalleidListaArchivo");
        });

        modelBuilder.Entity<MovilidadDeSiniestro>(entity =>
        {
            entity.ToTable("MovilidadDeSiniestros", "siniestros");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Analista)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Chasis)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.EstadoActual)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FechaAviso)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaOcurrencia)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Marca)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Motor)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NumeroSiniestro)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Placa)
                .HasMaxLength(6)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Movimiento>(entity =>
        {
            entity.HasKey(e => e.IdMovimiento);

            entity.ToTable("Movimientos", "siniestros");

            entity.Property(e => e.Creado).HasColumnType("datetime");
            entity.Property(e => e.CreadoPor)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Modificado).HasColumnType("datetime");
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.IdAnalistaNavigation).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.IdAnalista)
                .HasConstraintName("FK_MovimientosIdAnalista");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK_MovimientosIdEstado");

            entity.HasOne(d => d.IdSiniestroNavigation).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.IdSiniestro)
                .HasConstraintName("FK_MovimientosIdSiniestro");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("PK_Personas");

            entity.ToTable("personas", "siniestros");

            entity.Property(e => e.Creado).HasColumnType("datetime");
            entity.Property(e => e.CreadoPor)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Documento)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Genero)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Modificado).HasColumnType("datetime");
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTipoDocumentoNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdTipoDocumento)
                .HasConstraintName("FK_PersonasIdTipoDocumento");
        });

        modelBuilder.Entity<Ramo>(entity =>
        {
            entity.HasKey(e => e.IdRamo);

            entity.ToTable("Ramos", "siniestros");

            entity.Property(e => e.Codigo)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Creado).HasColumnType("datetime");
            entity.Property(e => e.CreadoPor)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Modificado).HasColumnType("datetime");
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Siniestro>(entity =>
        {
            entity.HasKey(e => e.IdSiniestro);

            entity.ToTable("Siniestros", "siniestros");

            entity.Property(e => e.BienesAfectados)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Creado).HasColumnType("datetime");
            entity.Property(e => e.CreadoPor)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FechaAviso).HasColumnType("datetime");
            entity.Property(e => e.FechaSiniestro).HasColumnType("datetime");
            entity.Property(e => e.Hechos)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Modificado).HasColumnType("datetime");
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.NombreAseguradoDeudor)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.NombreFuncionarioAsegurado)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.NumeroExpediente)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.NumeroPoliza)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.NumeroProceso)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.NumeroSiniestro)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PlacaAsegurado)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PlacaTerceroAfectado)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.TratamientoDatos)
                .HasMaxLength(500)
                .IsUnicode(false);            

            entity.HasOne(d => d.IdCiudadOcurrenciaNavigation).WithMany(p => p.SiniestroIdCiudadOcurrenciaNavigations)
                .HasForeignKey(d => d.IdCiudadOcurrencia)
                .HasConstraintName("FK_SiniestrosIdCiudadOcurrencia");

            entity.HasOne(d => d.IdCiudadResidenciaNavigation).WithMany(p => p.SiniestroIdCiudadResidenciaNavigations)
                .HasForeignKey(d => d.IdCiudadResidencia)
                .HasConstraintName("FK_SiniestrosIdCiudadResidencia");

            entity.HasOne(d => d.IdCoberturaNavigation).WithMany(p => p.Siniestros)
                .HasForeignKey(d => d.IdCobertura)
                .HasConstraintName("FK_SiniestrosidCobertura");

            entity.HasOne(d => d.IdEstadoSiniestroNavigation).WithMany(p => p.Siniestros)
                .HasForeignKey(d => d.IdEstadoSiniestro)
                .HasConstraintName("FK_SiniestrosIdEstadoSiniestro");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Siniestros)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK_SiniestrosidPersona");

            entity.HasOne(d => d.IdRamoNavigation).WithMany(p => p.Siniestros)
                .HasForeignKey(d => d.IdRamo)
                .HasConstraintName("FK_SiniestrosidRamo");

            entity.HasOne(d => d.IdTipoReclamacionNavigation).WithMany(p => p.Siniestros)
                .HasForeignKey(d => d.IdTipoReclamacion)
                .HasConstraintName("FK_SiniestrosidTipoReclamacion");

            entity.HasOne(d => d.IdTipoReclamanteNavigation).WithMany(p => p.Siniestros)
                .HasForeignKey(d => d.IdTipoReclamante)
                .HasConstraintName("FK_SiniestrosidTipoReclamante");

            entity.HasOne(d => d.IdTipoUsuarioNavigation).WithMany(p => p.Siniestros)
                .HasForeignKey(d => d.IdTipoUsuario)
                .HasConstraintName("FK_SiniestrosidTipoUsuario");
        });

        modelBuilder.Entity<TipoCertificacion>(entity =>
        {
            entity.HasKey(e => e.IdTipoCertificacion).HasName("PK__TipoCert__001F9CBED3BA0ABB");

            entity.ToTable("TipoCertificacion", "siniestros");

            entity.Property(e => e.Descripcion).HasMaxLength(50);
        });

        modelBuilder.Entity<TipoConsultum>(entity =>
        {
            entity.HasKey(e => e.IdTipoConsulta).HasName("PK__TipoCons__A86D310D4A2ECBFD");

            entity.ToTable("TipoConsulta", "siniestros");

            entity.Property(e => e.Descripcion).HasMaxLength(90);
        });

        modelBuilder.Entity<TiposDocumento>(entity =>
        {
            entity.HasKey(e => e.IdTipoDocumento);

            entity.ToTable("TiposDocumento", "siniestros");

            entity.Property(e => e.Codigo)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Creado).HasColumnType("datetime");
            entity.Property(e => e.CreadoPor)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Modificado).HasColumnType("datetime");
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TiposReclamacion>(entity =>
        {
            entity.HasKey(e => e.IdTipoReclamacion);

            entity.ToTable("TiposReclamacion", "siniestros");

            entity.Property(e => e.Creado).HasColumnType("datetime");
            entity.Property(e => e.CreadoPor)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Modificado).HasColumnType("datetime");
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TiposReclamante>(entity =>
        {
            entity.HasKey(e => e.IdTipoReclamante);

            entity.ToTable("TiposReclamante", "siniestros");

            entity.Property(e => e.Creado).HasColumnType("datetime");
            entity.Property(e => e.CreadoPor)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Modificado).HasColumnType("datetime");
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TiposUsuario>(entity =>
        {
            entity.HasKey(e => e.IdTipoUsuario);

            entity.ToTable("TiposUsuario", "siniestros");

            entity.Property(e => e.Creado).HasColumnType("datetime");
            entity.Property(e => e.CreadoPor)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Modificado).HasColumnType("datetime");
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.TipoSiniestro)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Vista)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
