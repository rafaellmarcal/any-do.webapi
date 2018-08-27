using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AnyDo.EnvelopeJson.Logic.EnvelopeJson;
using AnyDo.ModelData.Logic.Model;

namespace AnyDo.Business.Logic.IBusiness
{
    public interface ITarefaBusiness
    {
        void Add(ref TarefaEnvelopeJson entity);

        void Edit(ref TarefaEnvelopeJson entity);

        TarefaEnvelopeJson GetById(int id);

        List<TarefaEnvelopeJson> GetByPredicate(Expression<Func<Tarefa, bool>> predicate);

        List<TarefaEnvelopeJson> GetAll();

        TarefaEnvelopeJson ChangeSituation(int id);

        void Delete(int id);

        bool Exists(Expression<Func<Tarefa, bool>> predicate);

        bool Validate(TarefaEnvelopeJson instance);
    }
}
