using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Projeto.Data.Context;
using Projeto.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        //atributo
        private readonly DataContext context;

        //construtor utilizado para injeção de dependência
        public BaseRepository(DataContext context)
        {
            this.context = context;
        }

        public void Inserir(T obj)
        {
            context.Entry(obj).State = EntityState.Added;
            context.SaveChanges();
        }

        public void Atualizar(T obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Excluir(T obj)
        {
            context.Entry(obj).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public List<T> ObterTodos()
        {
            return context.Set<T>().ToList();
        }

        public T ObterPorId(int id)
        {
            return context.Set<T>().Find();
        }
    }
}
