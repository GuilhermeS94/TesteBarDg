﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace TesteBarDg.Infra.Models
{
    public partial class BarDgContext : DbContext
    {
        public BarDgContext()
        {
        }

        public BarDgContext(DbContextOptions<BarDgContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comandas> Comandas { get; set; }
        public virtual DbSet<Compras> Compras { get; set; }
        public virtual DbSet<Itens> Itens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(configuration.GetConnectionString("BarDgDb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comandas>(entity =>
            {
                entity.ToTable("comandas");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Compras>(entity =>
            {
                entity.ToTable("compras");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdComanda).HasColumnName("idComanda");

                entity.Property(e => e.IdItem).HasColumnName("idItem");

                entity.Property(e => e.ItemPromocional).HasColumnName("itemPromocional");

                entity.HasOne(d => d.IdComandaNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdComanda)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.IdItemNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdItem)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Itens>(entity =>
            {
                entity.ToTable("itens");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome");

                entity.Property(e => e.Valor).HasColumnName("valor");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
