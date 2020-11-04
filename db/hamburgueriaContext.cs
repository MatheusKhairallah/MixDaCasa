using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MixDaCasa.db
{
    public partial class hamburgueriaContext : DbContext
    {
        public hamburgueriaContext()
        {
        }

        public hamburgueriaContext(DbContextOptions<hamburgueriaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Burguer> Burguer { get; set; }
        public virtual DbSet<BurguerIngrediente> BurguerIngrediente { get; set; }
        public virtual DbSet<Ingrediente> Ingrediente { get; set; }
        public virtual DbSet<TipoIngrediente> TipoIngrediente { get; set; }
        public virtual DbSet<Unidade> Unidade { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=m2m7c5v8;database=hamburgueria");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Burguer>(entity =>
            {
                entity.ToTable("burguer");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(50);

                entity.Property(e => e.Preco)
                    .HasColumnName("preco")
                    .HasColumnType("decimal(6,2)");
            });

            modelBuilder.Entity<BurguerIngrediente>(entity =>
            {
                entity.HasKey(e => new { e.BurguerId, e.IngredienteId })
                    .HasName("PRIMARY");

                entity.ToTable("burguer_ingrediente");

                entity.HasIndex(e => e.IngredienteId)
                    .HasName("fk_burguer_ingrediente_ingrediente1_idx");

                entity.HasIndex(e => e.UnidadeId)
                    .HasName("fk_burguer_ingrediente_unidade1_idx");

                entity.Property(e => e.BurguerId)
                    .HasColumnName("burguer_id")
                    .HasMaxLength(36);

                entity.Property(e => e.IngredienteId)
                    .HasColumnName("ingrediente_id")
                    .HasMaxLength(36);

                entity.Property(e => e.Quantidade).HasColumnName("quantidade");

                entity.Property(e => e.UnidadeId)
                    .IsRequired()
                    .HasColumnName("unidade_id")
                    .HasMaxLength(5);

                entity.HasOne(d => d.Burguer)
                    .WithMany(p => p.BurguerIngrediente)
                    .HasForeignKey(d => d.BurguerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_burguer_ingrediente_burguer");

                entity.HasOne(d => d.Ingrediente)
                    .WithMany(p => p.BurguerIngrediente)
                    .HasForeignKey(d => d.IngredienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_burguer_ingrediente_ingrediente1");

                entity.HasOne(d => d.Unidade)
                    .WithMany(p => p.BurguerIngrediente)
                    .HasForeignKey(d => d.UnidadeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_burguer_ingrediente_unidade1");
            });

            modelBuilder.Entity<Ingrediente>(entity =>
            {
                entity.ToTable("ingrediente");

                entity.HasIndex(e => e.TipoIngredienteId)
                    .HasName("fk_ingrediente_tipo_ingrediente1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(50);

                entity.Property(e => e.TipoIngredienteId).HasColumnName("tipo_ingrediente_id");

                entity.HasOne(d => d.TipoIngrediente)
                    .WithMany(p => p.Ingrediente)
                    .HasForeignKey(d => d.TipoIngredienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ingrediente_tipo_ingrediente1");
            });

            modelBuilder.Entity<TipoIngrediente>(entity =>
            {
                entity.ToTable("tipo_ingrediente");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Unidade>(entity =>
            {
                entity.ToTable("unidade");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(5);

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
