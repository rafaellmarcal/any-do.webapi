using System;
using System.Linq.Expressions;
using AnyDo.ModelData.Logic.Model;
using AnyDo.EnvelopeJson.Logic.EnvelopeJson;
using ExpressMapper.Extensions;
using AnyDo.Business.Logic.IBusiness;
using AnyDo.Service.Logic.IService;
using AnyDo.Service.Logic.Service;
using ExpressMapper;

namespace AnyDo.Business.Logic.Business
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        private IUsuarioService usuarioService;

        public UsuarioBusiness()
        {
            this.usuarioService = new UsuarioService();
        }

        public void Add(ref UsuarioEnvelopeJson entity)
        {
            try
            {
                Usuario usuario = entity.Map<UsuarioEnvelopeJson, Usuario>();
                this.usuarioService.Add(usuario);
                entity = usuario.Map<Usuario, UsuarioEnvelopeJson>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UsuarioEnvelopeJson Login(UsuarioEnvelopeJson entity)
        {
            try
            {
                Mapper.Register<Usuario, UsuarioEnvelopeJson>().Ignore(u => u.Senha);
                Usuario usuario = this.usuarioService.GetByPredicate(u => u.Email.Equals(entity.Email) && u.Senha.Equals(entity.Senha));
                UsuarioEnvelopeJson usuarioLogado = usuario.Map<Usuario, UsuarioEnvelopeJson>();
                return usuarioLogado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Exists(Expression<Func<Usuario, bool>> predicate)
        {
            try
            {
                return this.usuarioService.Exists(predicate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Validate(UsuarioEnvelopeJson instance)
        {
            bool valid = true;

            if (instance == null)
            {
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(instance.Nome))
            {
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(instance.Email))
            {
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(instance.Senha))
            {
                valid = false;
            }

            return valid;
        }
    }
}
