using AnyDo.ModelData.Logic.Model;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace AnyDo.Service.Logic.IService
{
    public interface ITarefaService
    {
        Tarefa Add(Tarefa entity);

        Tarefa Edit(Tarefa entity);

        void Delete(Tarefa entity);

        Tarefa GetById(int id);

        IQueryable<Tarefa> GetAll();

        bool Exists(Expression<Func<Tarefa, bool>> predicate);
    }
}
