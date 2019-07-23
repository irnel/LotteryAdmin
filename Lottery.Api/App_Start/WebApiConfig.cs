using System.Web.Http;

namespace Lottery.Infrastructure
{
    /// <summary>
    /// Web API config
    /// </summary>
    /// 
    public static class WebApiConfig
    {
        /// <summary>
        /// Register global config
        /// </summary>
        /// <param name="config"></param>
        /// 
        public static void Register(HttpConfiguration config)
        {
            // Remove the XML formatter
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
