using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.Application;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace AnyDoWebAPI
{
    /// <summary>
    /// Classe de configuração da Web API
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Método que registra as configurações da Web API.
        /// </summary>
        public static void Register(HttpConfiguration config)
        {
            // Serviços e configuração da API da Web

            // Rotas da API da Web
            config.MapHttpAttributeRoutes();
            config.EnableCors();
            config.Routes.MapHttpRoute(
                name: "Any.do Swagger Page",
                routeTemplate: "",
                defaults: null,
                constraints: null,
                handler: new RedirectHandler(SwaggerDocsConfig.DefaultRootUrlResolver, "swagger/ui/index")
            );

            JsonMediaTypeFormatter jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            JsonSerializerSettings jSettings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };
            jsonFormatter.SerializerSettings = jSettings;
        }
    }
}
