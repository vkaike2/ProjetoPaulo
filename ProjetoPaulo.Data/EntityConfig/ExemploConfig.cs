using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoPaulo.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoPaulo.Data.EntityConfig
{
    public class ExemploConfig : IEntityTypeConfiguration<Exemplo>
    {
        public void Configure(EntityTypeBuilder<Exemplo> builder)
        {
            builder.ToTable("tb_exemplo");

            builder.HasKey(e => e.Id).HasName("pk_tb_exemplo");

            builder.Property(e => e.Id)
                .HasColumnName("ex_id")
                .IsRequired();

            builder.Property(e => e.Descricao)
                .HasColumnName("ex_descricao");
        }
    }
}
