using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GestaoParquesAPI.Models;

public partial class GestaoParquesContext : DbContext
{
    public GestaoParquesContext()
    {
    }

    public GestaoParquesContext(DbContextOptions<GestaoParquesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CodigoPostal> CodigoPostals { get; set; }

    public virtual DbSet<Estrutura> Estruturas { get; set; }

    public virtual DbSet<Fauna> Faunas { get; set; }

    public virtual DbSet<Flora> Floras { get; set; }

    public virtual DbSet<Funcao> Funcaos { get; set; }

    public virtual DbSet<Funcionario> Funcionarios { get; set; }

    public virtual DbSet<HistoricoOcorrencium> HistoricoOcorrencia { get; set; }

    public virtual DbSet<Ocorrencium> Ocorrencia { get; set; }

    public virtual DbSet<Parque> Parques { get; set; }

    public virtual DbSet<QrCode> QrCodes { get; set; }

    public virtual DbSet<Rio> Rios { get; set; }

    public virtual DbSet<StatusOcorrencium> StatusOcorrencia { get; set; }

    public virtual DbSet<TableLog> TableLogs { get; set; }

    public virtual DbSet<TipoEstrutura> TipoEstruturas { get; set; }

    public virtual DbSet<TipoOcorrencium> TipoOcorrencia { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Zona> Zonas { get; set; }

    public virtual DbSet<ZonaFauna> ZonaFaunas { get; set; }

    public virtual DbSet<ZonaFlora> ZonaFloras { get; set; }

    public virtual DbSet<ZonaRio> ZonaRios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=AppConnectionString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CodigoPostal>(entity =>
        {
            entity.HasKey(e => e.IdCodPostal).HasName("PK_idCodPostal");

            entity.ToTable("CodigoPostal");

            entity.Property(e => e.Concelho).HasMaxLength(50);
            entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");
            entity.Property(e => e.DataCriacao).HasColumnType("datetime");
            entity.Property(e => e.Freguesia).HasMaxLength(50);
            entity.Property(e => e.Rua).HasMaxLength(100);
        });

        modelBuilder.Entity<Estrutura>(entity =>
        {
            entity.HasKey(e => e.IdEstrutura).HasName("PK_idEstrutura");

            entity.ToTable("Estrutura");

            entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");
            entity.Property(e => e.DataCriacao).HasColumnType("datetime");

            entity.HasOne(d => d.IdTipoEstruturaNavigation).WithMany(p => p.Estruturas)
                .HasForeignKey(d => d.IdTipoEstrutura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TipoEstrutura_Estrutura");

            entity.HasOne(d => d.IdZonaNavigation).WithMany(p => p.Estruturas)
                .HasForeignKey(d => d.IdZona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Zonas_ZonaEstrutura");
        });

        modelBuilder.Entity<Fauna>(entity =>
        {
            entity.HasKey(e => e.IdFauna).HasName("PK_idFauna");

            entity.ToTable("Fauna");

            entity.Property(e => e.CategoriaFauna).HasMaxLength(50);
            entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");
            entity.Property(e => e.DataCriacao).HasColumnType("datetime");
            entity.Property(e => e.EspecieFauna).HasMaxLength(50);
            entity.Property(e => e.NomeCientificoFauna).HasMaxLength(100);
        });

        modelBuilder.Entity<Flora>(entity =>
        {
            entity.HasKey(e => e.IdFlora).HasName("PK_idFlora");

            entity.ToTable("Flora");

            entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");
            entity.Property(e => e.DataCriacao).HasColumnType("datetime");
            entity.Property(e => e.EspecieFlora).HasMaxLength(50);
            entity.Property(e => e.NomeCientificoFlora).HasMaxLength(100);
            entity.Property(e => e.TipoPlanta).HasMaxLength(50);
        });

        modelBuilder.Entity<Funcao>(entity =>
        {
            entity.HasKey(e => e.IdFuncao).HasName("PK_IdFuncao");

            entity.ToTable("Funcao");

            entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");
            entity.Property(e => e.DataCriacao).HasColumnType("datetime");
            entity.Property(e => e.NomeFuncao)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Funcionario>(entity =>
        {
            entity.HasKey(e => e.IdFuncionario).HasName("PK_IdFuncionario");

            entity.ToTable("Funcionario");

            entity.HasIndex(e => e.IdUser, "UQ__Funciona__B7C926392D10F786").IsUnique();

            entity.Property(e => e.DataAdmissao).HasColumnType("datetime");
            entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");
            entity.Property(e => e.DataCriacao).HasColumnType("datetime");
            entity.Property(e => e.DataNascimento).HasColumnType("datetime");
            entity.Property(e => e.NomeFuncionario)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdParqueNavigation).WithMany(p => p.Funcionarios)
                .HasForeignKey(d => d.IdParque)
                .HasConstraintName("FK_Funcionario_IdParque");

            entity.HasOne(d => d.IdUserNavigation).WithOne(p => p.Funcionario)
                .HasForeignKey<Funcionario>(d => d.IdUser)
                .HasConstraintName("FK_Funcionario_IdUser");
        });

        modelBuilder.Entity<HistoricoOcorrencium>(entity =>
        {
            entity.HasKey(e => new { e.IdStatusOcorrencia, e.IdFuncionario, e.IdOcorrencia });

            entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");
            entity.Property(e => e.DataCriacao).HasColumnType("datetime");
            entity.Property(e => e.DataModificacao).HasColumnType("datetime");
            entity.Property(e => e.Descricao).HasMaxLength(500);

            entity.HasOne(d => d.IdFuncionarioNavigation).WithMany(p => p.HistoricoOcorrencia)
                .HasForeignKey(d => d.IdFuncionario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Funcionario_HistoricoOcorrencia");

            entity.HasOne(d => d.IdOcorrenciaNavigation).WithMany(p => p.HistoricoOcorrencia)
                .HasForeignKey(d => d.IdOcorrencia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ocorrencia_HistoricoOcorrencia");

            entity.HasOne(d => d.IdStatusOcorrenciaNavigation).WithMany(p => p.HistoricoOcorrencia)
                .HasForeignKey(d => d.IdStatusOcorrencia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StatusOcorrencia_HistoricoOcorrencia");
        });

        modelBuilder.Entity<Ocorrencium>(entity =>
        {
            entity.HasKey(e => e.IdOcorrencia);

            entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");
            entity.Property(e => e.DataCriacao).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);

            entity.HasOne(d => d.IdTipoOcorrenciaNavigation).WithMany(p => p.Ocorrencia)
                .HasForeignKey(d => d.IdTipoOcorrencia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TipoOcorrencia_Ocorrencia");

            entity.HasOne(d => d.IdZonaNavigation).WithMany(p => p.Ocorrencia)
                .HasForeignKey(d => d.IdZona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Zonas_Ocorrencia");
        });

        modelBuilder.Entity<Parque>(entity =>
        {
            entity.HasKey(e => e.IdParque).HasName("PK_idParque");

            entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");
            entity.Property(e => e.DataCriacao).HasColumnType("datetime");
            entity.Property(e => e.IdCodPostal).HasColumnName("idCodPostal");
            entity.Property(e => e.NomeParque).HasMaxLength(50);

            entity.HasOne(d => d.IdCodPostalNavigation).WithMany(p => p.Parques)
                .HasForeignKey(d => d.IdCodPostal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CodPostal_Parque");
        });

        modelBuilder.Entity<QrCode>(entity =>
        {
            entity.HasKey(e => e.IdQrCode).HasName("PK_IdQrCode");

            entity.ToTable("QrCode");

            entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");
            entity.Property(e => e.DataCriacao).HasColumnType("datetime");
            entity.Property(e => e.Link).HasMaxLength(200);
        });

        modelBuilder.Entity<Rio>(entity =>
        {
            entity.HasKey(e => e.IdRio).HasName("PK_idRio");

            entity.ToTable("Rio");

            entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");
            entity.Property(e => e.DataCriacao).HasColumnType("datetime");
            entity.Property(e => e.NomeRio).HasMaxLength(50);
        });

        modelBuilder.Entity<StatusOcorrencium>(entity =>
        {
            entity.HasKey(e => e.IdStatusOcorrencia);

            entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");
            entity.Property(e => e.DataCriacao).HasColumnType("datetime");
            entity.Property(e => e.DescricaoStatus).HasMaxLength(500);
        });

        modelBuilder.Entity<TableLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__TableLog__5E5486484AD5844E");

            entity.ToTable("TableLog");

            entity.Property(e => e.Data)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Observacao).HasMaxLength(255);
            entity.Property(e => e.Status).HasDefaultValueSql("(xact_state())");
            entity.Property(e => e.TransactionId).HasDefaultValueSql("(scope_identity())");
            entity.Property(e => e.UserId)
                .HasMaxLength(30)
                .HasDefaultValueSql("(original_login())");
        });

        modelBuilder.Entity<TipoEstrutura>(entity =>
        {
            entity.HasKey(e => e.IdTipoEstrutura).HasName("PK_idTipoEstrutura");

            entity.ToTable("TipoEstrutura");

            entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");
            entity.Property(e => e.DataCriacao).HasColumnType("datetime");
            entity.Property(e => e.DescricaoTipoEstrutura).HasMaxLength(500);
            entity.Property(e => e.NomeTipoEstrutura).HasMaxLength(50);
        });

        modelBuilder.Entity<TipoOcorrencium>(entity =>
        {
            entity.HasKey(e => e.IdTipoOcorrencia);

            entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");
            entity.Property(e => e.DataCriacao).HasColumnType("datetime");
            entity.Property(e => e.NomeTipoOcorrencia).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK_IdUser");

            entity.ToTable("User");

            entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");
            entity.Property(e => e.DataCriacao).HasColumnType("datetime");
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.UserName).HasMaxLength(10);

            entity.HasOne(d => d.IdFuncaoNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdFuncao)
                .HasConstraintName("FK_User_IdFuncao");
        });

        modelBuilder.Entity<Zona>(entity =>
        {
            entity.HasKey(e => e.IdZona).HasName("PK_IdZona");

            entity.Property(e => e.Cor).HasMaxLength(10);
            entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");
            entity.Property(e => e.DataCriacao).HasColumnType("datetime");
            entity.Property(e => e.NomeZona).HasMaxLength(50);

            entity.HasOne(d => d.IdParqueNavigation).WithMany(p => p.Zonas)
                .HasForeignKey(d => d.IdParque)
                .HasConstraintName("FK_Parque_Zonas");

            entity.HasOne(d => d.IdQrCodeNavigation).WithMany(p => p.Zonas)
                .HasForeignKey(d => d.IdQrCode)
                .HasConstraintName("FK_QrCode_Zonas");
        });

        modelBuilder.Entity<ZonaFauna>(entity =>
        {
            entity.HasKey(e => new { e.IdFauna, e.IdZona });

            entity.ToTable("ZonaFauna");

            entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");
            entity.Property(e => e.DataCriacao).HasColumnType("datetime");
            entity.Property(e => e.Descricao).HasMaxLength(500);

            entity.HasOne(d => d.IdFaunaNavigation).WithMany(p => p.ZonaFaunas)
                .HasForeignKey(d => d.IdFauna)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Fauna_ZonaFauna");

            entity.HasOne(d => d.IdZonaNavigation).WithMany(p => p.ZonaFaunas)
                .HasForeignKey(d => d.IdZona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Zonas_ZonaFauna");
        });

        modelBuilder.Entity<ZonaFlora>(entity =>
        {
            entity.HasKey(e => new { e.IdFlora, e.IdZona });

            entity.ToTable("ZonaFlora");

            entity.Property(e => e.IdFlora).HasColumnName("idFlora");
            entity.Property(e => e.IdZona).HasColumnName("idZona");
            entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");
            entity.Property(e => e.DataCriacao).HasColumnType("datetime");
            entity.Property(e => e.Descricao).HasMaxLength(500);

            entity.HasOne(d => d.IdFloraNavigation).WithMany(p => p.ZonaFloras)
                .HasForeignKey(d => d.IdFlora)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Flora_ZonaFlora");

            entity.HasOne(d => d.IdZonaNavigation).WithMany(p => p.ZonaFloras)
                .HasForeignKey(d => d.IdZona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Zonas_ZonaFlora");
        });

        modelBuilder.Entity<ZonaRio>(entity =>
        {
            entity.HasKey(e => new { e.IdZona, e.IdRio });

            entity.ToTable("ZonaRio");

            entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");
            entity.Property(e => e.DataCriacao).HasColumnType("datetime");

            entity.HasOne(d => d.IdRioNavigation).WithMany(p => p.ZonaRios)
                .HasForeignKey(d => d.IdRio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rio_ZonaRio");

            entity.HasOne(d => d.IdZonaNavigation).WithMany(p => p.ZonaRios)
                .HasForeignKey(d => d.IdZona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Zonas_ZonaRio");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
