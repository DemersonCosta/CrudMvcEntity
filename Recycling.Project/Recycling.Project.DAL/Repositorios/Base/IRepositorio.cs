using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recycling.Project.DAL.Repositorios.Base
{
    interface IRepositorio<T> where T: class
    {
        IQueryable<T> GetAll();

        IQueryable<T> Get(Func<T, bool> predicate);

        T Find(params object[] key);

        void Atualizar(T obj);

        void SalvarTodos();

        void Adicionar(T obj);

        void Excluir(Func<T, bool> predicate);

    }
}
