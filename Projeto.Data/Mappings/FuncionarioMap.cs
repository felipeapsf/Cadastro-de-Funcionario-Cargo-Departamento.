using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Data.Mappings
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("Funcionario");
            builder.HasKey(f => f.IdFuncionario);

            builder.Property(f => f.IdFuncionario)
                .HasColumnName("IdFuncionario");

            builder.Property(f => f.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(f => f.Salario)
                .HasColumnName("Salario")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(f => f.DataAdmissao)
                .HasColumnName("DataAdmissao")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(f => f.IdCargo)
                .HasColumnName("IdCargo")
                .IsRequired();

            builder.Property(f => f.IdDepartamento)
                .HasColumnName("IdDepartamento")
                .IsRequired();

            #region Mapeamento dos Relacionamentos

            //1 para MUITOS
            builder.HasOne(f => f.Cargo) //Funcionario TEM 1 Cargo
                .WithMany(f => f.Funcionarios) //Cargo TEM MUITOS Funcionários
                .HasForeignKey(f => f.IdCargo); //Chave estrangeira

            //1 para MUITOS
            builder.HasOne(f => f.Departamento) //Funcionario TEM 1 Departamento
                .WithMany(f => f.Funcionarios) //Departamento TEM MUITOS Funcionários
                .HasForeignKey(f => f.IdDepartamento); //Chave estrangeira

            #endregion
        }
    }
}
