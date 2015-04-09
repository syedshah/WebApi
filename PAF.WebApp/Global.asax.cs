using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using PAF.Services;
using PAFRepository.Repositories;

namespace PAF.WebApp
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterWebApiFilterProvider(config);
            RegisterTypes(builder);
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //GlobalConfiguration.Configure(configuration => SwaggerConfig.Register());
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private static void RegisterTypes(ContainerBuilder builder)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["PAFContext"].ConnectionString;
            var serviceAssemblies = Assembly.Load("Services");
            builder.RegisterAssemblyTypes(serviceAssemblies).AsImplementedInterfaces();

            var repositoryAssemblies = Assembly.Load("PAFRepository");
            builder.RegisterAssemblyTypes(repositoryAssemblies)
                .AsImplementedInterfaces()
                .WithParameter(new NamedParameter("connectionString", connectionString));

            builder.RegisterType<LocalityRepository>()
                .As<PAFRepository.Interfaces.ILocalityRepository>()
                .WithParameter(new NamedParameter("connectionString", connectionString));

            var pafService = Assembly.Load("PAF.Services");
            builder.RegisterAssemblyTypes(pafService).AsImplementedInterfaces();

            builder.RegisterType<AddressService>().AsImplementedInterfaces();
            
        }
    }
}
