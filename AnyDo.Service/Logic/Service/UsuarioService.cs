using System;
using System.Linq;
using System.Linq.Expressions;
using AnyDo.ModelData.Logic.Model;
using AnyDo.Service.Logic.IService;

namespace AnyDo.Service.Logic.Service
{
    public class UsuarioService : IUsuarioService
    {
        private AnyDoDatabaseEntities db = new AnyDoDatabaseEntities();

        public Usuario Add(Usuario entity)
        {
            try
            {
                db.Usuario.Add(entity);
                db.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario GetByPredicate(Expression<Func<Usuario, bool>> predicate)
        {
            try
            {
                return db.Usuario.SingleOrDefault(predicate);
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
                return db.Usuario.Count(predicate) > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
