using Projeto.Data.Context;
using Projeto.Data.Contracts;
using Projeto.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Data.Repositories
{
    public class FuncionarioRepository : BaseRepository<Funcionario>, IFuncionarioRepository
    {
        //atributo
        private readonly DataContext context;

        //contrutor para injeção de dependência
        public FuncionarioRepository(DataContext context) : base(context) //contrutor da superclasse
        {
            this.context = context;
        }
    }
}
