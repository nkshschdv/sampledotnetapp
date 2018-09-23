using System;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Owin;
using Technossus.Reincarnation.Data;

[assembly: OwinStartup(typeof(Technossus.Reincarnation.WebApi.Startup))]

namespace Technossus.Reincarnation.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            var builder = new ContainerBuilder();

            var config = new HttpConfiguration();

            //SwaggerConfig.Register();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies()).Where(t => t.Name.EndsWith("Manager")).AsImplementedInterfaces();
            // builder.Register(ctx => new ReincarnationContext(HttpContext.Current.User.Identity.GetUserId()));
            // builder.Register(c => new UploadManager(new ReincarnationContext())).As<IUploadManager>().InstancePerRequest();
            builder.Register(c => new ReincarnationContext()).InstancePerRequest();

            var container = builder.Build();
            //ConfigureAuth(app);

            WebApiConfig.Register(config);

            // REPLACE THE MVC DEPENDENCY RESOLVER WITH AUTOFAC
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            config.DependencyResolver = webApiResolver;

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
            app.UseWebApi(config);
            app.UseAutofacMvc();

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
