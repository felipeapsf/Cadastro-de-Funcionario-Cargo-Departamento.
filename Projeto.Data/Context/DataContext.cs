using Microsoft.EntityFrameworkCore;
using Projeto.Data.Entities;
using Projeto.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Data.Context
{
    public class DataContext : DbContext
    {
        //contrutor para receber a string de conexão que será
        //enviad pela classe Startup.cs
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //sobrescrita do método OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //adicionar cada classe de mapeamento do EntityFramework
            modelBuilder.ApplyConfiguration(new FuncionarioMap());
            modelBuilder.ApplyConfiguration(new CargoMap());
            modelBuilder.ApplyConfiguration(new DepartamentoMap());
        }

        //declarar uma proprierade DbSet para cada entidade
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
    }
}
