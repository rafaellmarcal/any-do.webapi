using System;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using AnyDo.Business.Logic.Business;
using AnyDo.Business.Logic.IBusiness;
using AnyDo.EnvelopeJson.Logic.EnvelopeJson;

namespace AnyDoWebAPI.Controllers
{
    /// <summary>
    /// Classe que gerencia os usuários
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsuarioController : ApiController
    {
        private IUsuarioBusiness usuarioBusiness = new UsuarioBusiness();

        /// <summary>
        /// Método de cadastro de usuários.
        /// </summary>
        /// <param name="usuario">Objeto para cadastro</param>
        /// <returns></returns>
        [HttpPost]
        [Route("usuarios")]
        [ResponseType(typeof(UsuarioEnvelopeJson))]
        public IHttpActionResult Post(UsuarioEnvelopeJson usuario)
        {
            try
            {
                if (!this.usuarioBusiness.Validate(usuario))
                {
                    return BadRequest("As informações do registro não são válidas!");
                }

                this.usuarioBusiness.Add(ref usuario);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Método que realiza o login do usuário.
        /// </summary>
        /// <param name="usuario">Objeto usuário com dados para o login</param>
        /// <returns></returns>
        [HttpPost]
        [Route("usuarios/login")]
        [ResponseType(typeof(UsuarioEnvelopeJson))]
        public IHttpActionResult PostLogin(UsuarioEnvelopeJson usuario)
        {
            try
            {
                if (!this.usuarioBusiness.Exists(u => u.Email.Equals(usuario.Email) && u.Senha.Equals(usuario.Senha)))
                {
                    return BadRequest("Nenhum registro encontrado!");
                }

                UsuarioEnvelopeJson usuarioLogado = this.usuarioBusiness.Login(usuario);

                return Ok(usuarioLogado);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}