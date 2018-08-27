using System;
using System.Linq.Expressions;
using AnyDo.ModelData.Logic.Model;
using AnyDo.EnvelopeJson.Logic.EnvelopeJson;

namespace AnyDo.Business.Logic.IBusiness
{
    public interface IUsuarioBusiness
    {
        void Add(ref UsuarioEnvelopeJson entity);

        UsuarioEnvelopeJson Login(UsuarioEnvelopeJson entity);

        bool Exists(Expression<Func<Usuario, bool>> predicate);

        bool Validate(UsuarioEnvelopeJson instance);
    }
}
