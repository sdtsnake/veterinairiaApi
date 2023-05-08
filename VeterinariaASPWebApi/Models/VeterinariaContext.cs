using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VeterinariaASPWebApi.Models;

public partial class VeterinariaContext : DbContext
{
    public VeterinariaContext()
    {
    }

    public VeterinariaContext(DbContextOptions<VeterinariaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Colaborador> Colaboradores { get; set; }

    public virtual DbSet<DetallesHistoriasClinica> DetallesHistoriasClinicas { get; set; }

    public virtual DbSet<HistoriasClinica> HistoriasClinicas { get; set; }

    public virtual DbSet<Mascota> Mascotas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=veterinaria;Username=root;Password=root");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Colaborador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("colaboradores_pkey");

            entity.ToTable("colaboradores");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(255)
                .HasColumnName("apellido");
            entity.Property(e => e.Cargo)
                .HasMaxLength(255)
                .HasColumnName("cargo");
            entity.Property(e => e.DocumentoIdentificacion).HasColumnName("documento_identificacion");
            entity.Property(e => e.Especialidad)
                .HasMaxLength(255)
                .HasColumnName("especialidad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(3)
                .HasColumnName("tipo_documento");
        });

        modelBuilder.Entity<DetallesHistoriasClinica>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("detalles_historias_clinicas_pkey");

            entity.ToTable("detalles_historias_clinicas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Alimentacion)
                .HasMaxLength(255)
                .HasColumnName("alimentacion");
            entity.Property(e => e.ColaboradorId).HasColumnName("colaborador_id");
            entity.Property(e => e.FechaHora)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_hora");
            entity.Property(e => e.FrecuenciaCardiaca).HasColumnName("frecuencia_cardiaca");
            entity.Property(e => e.FrecuenciaRespiratoria).HasColumnName("frecuencia_respiratoria");
            entity.Property(e => e.Habitad)
                .HasMaxLength(255)
                .HasColumnName("habitad");
            entity.Property(e => e.HistoriaClinicaId).HasColumnName("historia_clinica_id");
            entity.Property(e => e.Observacion)
                .HasMaxLength(255)
                .HasColumnName("observacion");
            entity.Property(e => e.Peso).HasColumnName("peso");
            entity.Property(e => e.Temperatura)
                .HasMaxLength(255)
                .HasColumnName("temperatura");

            entity.HasOne(d => d.Colaborador).WithMany(p => p.DetallesHistoriasClinicas)
                .HasForeignKey(d => d.ColaboradorId)
                .HasConstraintName("detalles_historias_clinicas_colaborador_id_fkey");

            entity.HasOne(d => d.HistoriaClinica).WithMany(p => p.DetallesHistoriasClinicas)
                .HasForeignKey(d => d.HistoriaClinicaId)
                .HasConstraintName("detalles_historias_clinicas_historia_clinica_id_fkey");
        });

        modelBuilder.Entity<HistoriasClinica>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("historias_clinicas_pkey");

            entity.ToTable("historias_clinicas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FechaCreacion).HasColumnName("fecha_creacion");
            entity.Property(e => e.MascotaId).HasColumnName("mascota_id");

            entity.HasOne(d => d.Mascota).WithMany(p => p.HistoriasClinicas)
                .HasForeignKey(d => d.MascotaId)
                .HasConstraintName("fk_historia_clinica_mascotas");
        });

        modelBuilder.Entity<Mascota>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("macotas_pkey");

            entity.ToTable("mascotas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.Raza)
                .HasMaxLength(255)
                .HasColumnName("raza");
            entity.Property(e => e.Sexo)
                .HasMaxLength(255)
                .HasColumnName("sexo");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Mascota)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("macotas_usuario_id_fkey");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usuario_pkey");

            entity.ToTable("usuarios");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(255)
                .HasColumnName("apellido");
            entity.Property(e => e.DocumentoIdentificacion).HasColumnName("documento_identificacion");
            entity.Property(e => e.Estado)
                .HasMaxLength(255)
                .HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.Sexo).HasColumnName("sexo");
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(255)
                .HasColumnName("tipo_documento");
        });
        modelBuilder.HasSequence("colaboradores_id_seq").HasMax(9999L);
        modelBuilder.HasSequence("detalles_historias_clinicas_id_seq").HasMax(9999L);
        modelBuilder.HasSequence("historias_clinicas_id_seq").HasMax(9999L);
        modelBuilder.HasSequence("mascotas_id_seq").HasMax(9999L);
        modelBuilder.HasSequence("usuarios_id_seq").HasMax(9999L);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
