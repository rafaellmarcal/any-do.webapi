using System.Web.Http;
using WebActivatorEx;
using AnyDoWebAPI;
using Swashbuckle.Application;
using System;
using System.Linq;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace AnyDoWebAPI
{
    /// <summary>
    /// Classe de configuração do Swagger
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// Método que registra as configurações do Swagger.
        /// </summary>
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                    c.SingleApiVersion("v1", "Any.do Swagger");
                    c.IncludeXmlComments(GetXmlCommentsPath());
                })
                .EnableSwaggerUi(c => { });
        }

        /// <summary>
        /// Método que formata o caminho da documentação xml do Swagger.
        /// </summary>
        /// <returns></returns>
        protected static string GetXmlCommentsPath()
        {
            return String.Format(@"{0}\SwaggerDocs\AnyDoWebAPI.xml", AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
