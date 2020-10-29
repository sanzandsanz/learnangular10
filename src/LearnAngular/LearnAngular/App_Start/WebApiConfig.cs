using System.Web.Http;
using System.Web.Http.Cors;

namespace LearnAngular
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Allow to use all domains to call the api
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // To return data in Json formatter
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
        }
    }
}
