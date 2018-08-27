using System;
using System.Linq.Expressions;
using AnyDo.ModelData.Logic.Model;

namespace AnyDo.Service.Logic.IService
{
    public interface IUsuarioService
    {
        Usuario Add(Usuario entity);

        Usuario GetByPredicate(Expression<Func<Usuario, bool>> predicate);

        bool Exists(Expression<Func<Usuario, bool>> predicate);
    }
}
