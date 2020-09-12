using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Data.Mappings
{
    public class CargoMap : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.ToTable("Cargo");
            builder.HasKey(c => c.IdCargo);

            builder.Property(c => c.IdCargo)
                .HasColumnName("IdCargo");

            builder.Property(c => c.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(c => c.Descricao)
                .HasColumnName("Descricao")
                .HasMaxLength(500)
                .IsRequired();
        }
    }
}
