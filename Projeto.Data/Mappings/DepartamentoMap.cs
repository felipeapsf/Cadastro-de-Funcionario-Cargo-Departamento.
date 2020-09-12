using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Data.Mappings
{
    public class DepartamentoMap : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.ToTable("Departamento");
            builder.HasKey(d => d.IdDepartamento);

            builder.Property(d => d.IdDepartamento)
                .HasColumnName("IdDepartamento");

            builder.Property(d => d.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(d => d.Descricao)
                .HasColumnName("Descricao")
                .HasMaxLength(500)
                .IsRequired();
        }
    }
}
