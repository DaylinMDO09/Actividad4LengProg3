using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Actividad4LengProg3.Models;

public partial class BdMdoContext : DbContext
{
    public BdMdoContext()
    {
    }

    public BdMdoContext(DbContextOptions<BdMdoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Calificacione> Calificaciones { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Materia> Materias { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DAYLIN-PC;Database=BD_MDO;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Calificacione>(entity =>
        {
            entity.HasKey(e => e.Idcalificacion).HasName("PK__CALIFICA__E150C3296B8FB298");

            entity.ToTable("CALIFICACIONES");

            entity.Property(e => e.Idcalificacion).HasColumnName("IDCALIFICACION");
            entity.Property(e => e.Codigomateria)
                .HasMaxLength(20)
                .HasColumnName("CODIGOMATERIA");
            entity.Property(e => e.Matriculaestudiante)
                .HasMaxLength(15)
                .HasColumnName("MATRICULAESTUDIANTE");
            entity.Property(e => e.Nota)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("NOTA");
            entity.Property(e => e.Periodo)
                .HasMaxLength(20)
                .HasColumnName("PERIODO");

            entity.HasOne(d => d.CodigomateriaNavigation).WithMany(p => p.Calificaciones)
                .HasForeignKey(d => d.Codigomateria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CALIFICAC__CODIG__5BE2A6F2");

            entity.HasOne(d => d.MatriculaestudianteNavigation).WithMany(p => p.Calificaciones)
                .HasPrincipalKey(p => p.Matricula)
                .HasForeignKey(d => d.Matriculaestudiante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CALIFICAC__MATRI__5AEE82B9");
        });


        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.Idestudiante).HasName("PK__ESTUDIAN__3C38DCE90F4BDCB2");

            entity.ToTable("ESTUDIANTES");

            entity.HasIndex(e => e.Matricula, "UQ__ESTUDIAN__46A2F6887BEAE241").IsUnique();

            entity.Property(e => e.Idestudiante).HasColumnName("IDESTUDIANTE");
            entity.Property(e => e.Correoinstitucional)
                .HasMaxLength(100)
                .HasColumnName("CORREOINSTITUCIONAL");
            entity.Property(e => e.Estabecado).HasColumnName("ESTABECADO");
            entity.Property(e => e.Fechanac).HasColumnName("FECHANAC");
            entity.Property(e => e.Genero)
                .HasMaxLength(10)
                .HasColumnName("GENERO");
            entity.Property(e => e.Carrera).HasColumnName("CARRERA");
            entity.Property(e => e.Matricula)
                .HasMaxLength(15)
                .HasColumnName("MATRICULA");
            entity.Property(e => e.Nombrecompleto)
                .HasMaxLength(100)
                .HasColumnName("NOMBRECOMPLETO");
            entity.Property(e => e.Porcentajebeca).HasColumnName("PORCENTAJEBECA");
            entity.Property(e => e.Telefono).HasColumnName("TELEFONO");
            entity.Property(e => e.Terminosycondiciones).HasColumnName("TERMINOSYCONDICIONES");
            entity.Property(e => e.Tipoingreso)
                .HasMaxLength(50)
                .HasColumnName("TIPOINGRESO");
            entity.Property(e => e.Turno)
                .HasMaxLength(10)
                .HasColumnName("TURNO");

            entity.HasOne(d => d.IdcarreraNavigation).WithMany(p => p.Estudiantes)
                .HasForeignKey(d => d.Carrera)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ESTUDIANT__IDCAR__4E88ABD4");
        });

        modelBuilder.Entity<Materia>(entity =>
        {
            entity.HasKey(e => e.Codigomateria).HasName("PK__MATERIAS__E23818F6856BA339");

            entity.ToTable("MATERIAS");

            entity.Property(e => e.Codigomateria)
                .HasMaxLength(20)
                .HasColumnName("CODIGOMATERIA");
            entity.Property(e => e.Creditos).HasColumnName("CREDITOS");
            entity.Property(e => e.Idcarrera).HasColumnName("IDCARRERA");
            entity.Property(e => e.Nombremateria)
                .HasMaxLength(100)
                .HasColumnName("NOMBREMATERIA");

            entity.HasOne(d => d.IdcarreraNavigation).WithMany(p => p.Materia)
                .HasForeignKey(d => d.Idcarrera)
                .HasConstraintName("FK__MATERIAS__IDCARR__5812160E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
