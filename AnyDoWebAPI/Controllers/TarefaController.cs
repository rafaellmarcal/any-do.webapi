using System;
using System.Linq;
using System.Web.Http;
using System.Collections.Generic;
using System.Web.Http.Description;
using AnyDo.Business.Logic.Business;
using AnyDo.Business.Logic.IBusiness;
using AnyDo.EnvelopeJson.Logic.EnvelopeJson;
using System.Web.Http.Cors;

namespace AnyDoWebAPI.Controllers
{
    /// <summary>
    /// Classe que gerencia as tarefas.
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TarefaController : ApiController
    {
        private ITarefaBusiness tarefaBusiness = new TarefaBusiness();

        /// <summary>
        /// Método que retorna todas as tarefas cadastradas do usuário.
        /// </summary>
        /// <param name="usuarioid">Id do usuário</param>
        /// <returns></returns>
        [HttpGet]
        [Route("tarefas/usuario/{usuarioid:int}")]
        [ResponseType(typeof(TarefaEnvelopeJson))]
        public IHttpActionResult GetByUsuarioId(int usuarioid)
        {
            try
            {
                List<TarefaEnvelopeJson> tarefas = this.tarefaBusiness.GetByPredicate(t => t.UsuarioID == usuarioid);

                if (!tarefas.Any())
                {
                    return BadRequest("Nenhum registro encontrado!");
                }

                return Ok(tarefas);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Método que retorna registro pelo seu id.
        /// </summary>
        /// <param name="id">Id da tarefa</param>
        /// <returns></returns>
        [HttpGet]
        [Route("tarefas/{id:int}")]
        [ResponseType(typeof(TarefaEnvelopeJson))]
        public IHttpActionResult Get(int id)
        {
            try
            {
                TarefaEnvelopeJson tarefa = this.tarefaBusiness.GetById(id);

                if (tarefa == null)
                {
                    return BadRequest("Nenhum registro encontrado!");
                }

                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Método de cadastro de tarefas.
        /// </summary>
        /// <param name="tarefa">Objeto para cadastro</param>
        /// <returns></returns>
        [HttpPost]
        [Route("tarefas")]
        [ResponseType(typeof(TarefaEnvelopeJson))]
        public IHttpActionResult Post(TarefaEnvelopeJson tarefa)
        {
            try
            {
                if (!this.tarefaBusiness.Validate(tarefa))
                {
                    return BadRequest("As informações do registro não são válidas!");
                }

                this.tarefaBusiness.Add(ref tarefa);
                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Método de edição de tarefas.
        /// </summary>
        /// <param name="tarefa">Objeto para edição</param>
        /// <param name="id">Id da tarefa</param>
        /// <returns></returns>
        [HttpPut]
        [Route("tarefas/{id:int}")]
        [ResponseType(typeof(TarefaEnvelopeJson))]
        public IHttpActionResult Put(TarefaEnvelopeJson tarefa, int id)
        {
            try
            {
                if (!this.tarefaBusiness.Validate(tarefa))
                {
                    return BadRequest("As informações do registro não são válidas!");
                }

                if (id != tarefa.TarefaID)
                {
                    return BadRequest("O id da tarefa não corresponde com o do objeto!");
                }

                if (!this.tarefaBusiness.Exists(t => t.TarefaID == id))
                {
                    return BadRequest("Nenhum registro encontrado!");
                }

                this.tarefaBusiness.Edit(ref tarefa);

                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Método que realiza a alteração de uma tarefa para 'Concluída'.
        /// </summary>
        /// <param name="id">Id da tarefa</param>
        /// <returns></returns>
        [HttpGet]
        [Route("tarefas/{id:int}/concluir")]
        [ResponseType(typeof(TarefaEnvelopeJson))]
        public IHttpActionResult PutChangeSituation(int id)
        {
            try
            {
                if (!this.tarefaBusiness.Exists(t => t.TarefaID == id))
                {
                    return BadRequest("Nenhum registro encontrado!");
                }

                TarefaEnvelopeJson tarefa = this.tarefaBusiness.ChangeSituation(id);

                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Método para deletar tarefas.
        /// </summary>
        /// <param name="id">Id da tarefa</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("tarefas/{id:int}")]
        [ResponseType(typeof(TarefaEnvelopeJson))]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (!this.tarefaBusiness.Exists(t => t.TarefaID == id))
                {
                    return BadRequest("Nenhum registro encontrado!");
                }

                this.tarefaBusiness.Delete(id);

                return Ok(true);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
