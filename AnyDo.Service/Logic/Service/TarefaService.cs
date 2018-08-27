using System;
using System.Linq;
using System.Linq.Expressions;
using AnyDo.ModelData.Logic.Model;
using AnyDo.Service.Logic.IService;

namespace AnyDo.Service.Logic.Service
{
    public class TarefaService : ITarefaService
    {
        private AnyDoDatabaseEntities db = new AnyDoDatabaseEntities();

        public Tarefa Add(Tarefa entity)
        {
            try
            {
                db.Tarefa.Add(entity);
                db.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Tarefa entity)
        {
            try
            {
                db.Tarefa.Remove(entity);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Tarefa Edit(Tarefa entity)
        {
            try
            {
                db.Tarefa.Add(entity);
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Tarefa GetById(int id)
        {
            try
            {
                return db.Tarefa.SingleOrDefault(t => t.TarefaID == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<Tarefa> GetAll()
        {
            try
            {
                return db.Tarefa;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Exists (Expression<Func<Tarefa,bool>> predicate)
        {
            try
            {
                return db.Tarefa.Count(predicate) > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
