using Microsoft.EntityFrameworkCore;
using ProjetoPaulo.Data.Entity;
using ProjetoPaulo.Data.EntityConfig;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoPaulo.Data.Context
{
    public class PauloContext : DbContext
    {
        public DbSet<Exemplo> Exemplo { get; set; }

        public PauloContext()
        {

        }

        public PauloContext(DbContextOptions<PauloContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ExemploConfig());
        }
    }
}
