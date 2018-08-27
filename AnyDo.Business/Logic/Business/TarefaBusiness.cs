using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using AnyDo.ModelData.Logic.Model;
using AnyDo.EnvelopeJson.Logic.EnvelopeJson;
using ExpressMapper.Extensions;
using AnyDo.Business.Logic.IBusiness;
using AnyDo.Service.Logic.Service;
using AnyDo.Service.Logic.IService;

namespace AnyDo.Business.Logic.Business
{
    public class TarefaBusiness : ITarefaBusiness
    {
        private ITarefaService tarefaService;

        public TarefaBusiness()
        {
            this.tarefaService = new TarefaService();
        }

        public void Add(ref TarefaEnvelopeJson entity)
        {
            try
            {
                Tarefa tarefa = entity.Map<TarefaEnvelopeJson, Tarefa>();
                this.tarefaService.Add(tarefa);
                entity = tarefa.Map<Tarefa, TarefaEnvelopeJson>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TarefaEnvelopeJson ChangeSituation(int id)
        {
            try
            {
                Tarefa tarefa = this.tarefaService.GetById(id);
                tarefa.Concluida = !tarefa.Concluida;
                tarefa.DataConclusao = DateTime.Now;
                this.tarefaService.Edit(tarefa);
                TarefaEnvelopeJson entity = tarefa.Map<Tarefa, TarefaEnvelopeJson>();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                Tarefa entity = this.tarefaService.GetById(id);
                this.tarefaService.Delete(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Edit(ref TarefaEnvelopeJson entity)
        {
            try
            {
                Tarefa tarefa = entity.Map<TarefaEnvelopeJson, Tarefa>();
                this.tarefaService.Edit(tarefa);
                entity = tarefa.Map<Tarefa, TarefaEnvelopeJson>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TarefaEnvelopeJson GetById(int id)
        {
            try
            {
                Tarefa tarefa = this.tarefaService.GetById(id);
                TarefaEnvelopeJson entity = tarefa.Map<Tarefa, TarefaEnvelopeJson>();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TarefaEnvelopeJson> GetByPredicate(Expression<Func<Tarefa, bool>> predicate)
        {
            try
            {
                List<Tarefa> tarefas = this.tarefaService.GetAll().Where(predicate).ToList();
                List<TarefaEnvelopeJson> tarefasEnvelope = tarefas.Map<List<Tarefa>, List<TarefaEnvelopeJson>>();
                return tarefasEnvelope;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TarefaEnvelopeJson> GetAll()
        {
            try
            {
                List<Tarefa> tarefas = this.tarefaService.GetAll().ToList();
                List<TarefaEnvelopeJson> tarefasEnvelope = tarefas.Map<List<Tarefa>, List<TarefaEnvelopeJson>>();
                return tarefasEnvelope;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Exists(Expression<Func<Tarefa, bool>> predicate)
        {
            try
            {
                return this.tarefaService.Exists(predicate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Validate(TarefaEnvelopeJson instance)
        {
            bool valid = true;

            if(instance == null)
            {
                valid = false;
            }

            if (instance.UsuarioID == 0)
            {
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(instance.Titulo))
            {
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(instance.Descricao))
            {
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(instance.DataCadastro))
            {
                valid = false;
            }
            else
            {
                DateTime validDate;
                DateTime.TryParse(instance.DataCadastro, out validDate);
                if(validDate == DateTime.MinValue)
                {
                    valid = false;
                }
            }

            if (!string.IsNullOrWhiteSpace(instance.DataConclusao))
            {
                DateTime validDate;
                DateTime.TryParse(instance.DataConclusao, out validDate);
                if (validDate == DateTime.MinValue)
                {
                    valid = false;
                }
            }

            return valid;
        }
    }
}
