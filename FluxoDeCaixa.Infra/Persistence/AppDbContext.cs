using FluxoDeCaixa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace FluxoDeCaixa.Infra.Persistence

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Lancamento> Lancamentos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<SaldoDiario> SaldosDiarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
