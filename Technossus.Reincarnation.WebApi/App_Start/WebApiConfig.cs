using System.Web.Http;
using System.Web.Http.Batch;

namespace Technossus.Reincarnation.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //Enable batch API calls.
            //http://www.codeproject.com/Articles/855284/How-to-Avoid-API-Requests-On-Your-Page
            //https://aspnetwebstack.codeplex.com/wikipage?title=Web+API+Request+Batching
            config.Routes.MapHttpBatchRoute(
                routeName: "WebApiBatch",
                routeTemplate: "batch/$batch",
                batchHandler: new DefaultHttpBatchHandler(GlobalConfiguration.DefaultServer)
                {
                    ExecutionOrder = BatchExecutionOrder.NonSequential
                });
        }
    }
}
