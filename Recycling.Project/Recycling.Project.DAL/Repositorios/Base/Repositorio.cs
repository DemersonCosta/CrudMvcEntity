using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recycling.Project.DAL.Repositorios.Base
{
    public abstract class Repositorio<T> : IDisposable,
    IRepositorio<T> where T : class
    {
        RecyclingBanco ctx = new RecyclingBanco();

        public IQueryable<T> GetAll()
        {
            return ctx.Set<T>();
        }

        public IQueryable<T> Get(Func<T, bool> predicate)
        {
            return GetAll().Where(predicate).AsQueryable();
        }

        public T Find(params object[] key)
        {
            return ctx.Set<T>().Find(key);
        }

        public void Atualizar(T obj)
        {
            ctx.Entry(obj).State = EntityState.Modified;
        }

        public void SalvarTodos()
        {
            ctx.SaveChanges();
        }

        public void Adicionar(T obj)
        {
            ctx.Set<T>().Add(obj);
        }

        public void Excluir(Func<T, bool> predicate)
        {
            ctx.Set<T>()
                .Where(predicate).ToList()
                .ForEach(del => ctx.Set<T>().Remove(del));
        }

        public void Dispose()
        {
            ctx.Dispose();
        }
    }
}
