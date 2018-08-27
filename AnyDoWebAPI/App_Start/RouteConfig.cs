using System.Web.Mvc;
using System.Web.Routing;

namespace AnyDoWebAPI
{
    /// <summary>
    /// Classe de configurações de rota.
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Método que registra as configurações das rotas
        /// </summary>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
