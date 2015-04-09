using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using PAF.Services;

namespace PAF.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            RegisterTypes(builder);
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private static void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterControllers(typeof (MvcApplication).Assembly);

            String connectionString = ConfigurationManager.ConnectionStrings["PAFContext"].ConnectionString;

            //var configurationManagerWrapperAssembly = Assembly.Load("ConfigurationManagerWrapper");
            //builder.RegisterAssemblyTypes(configurationManagerWrapperAssembly).AsImplementedInterfaces();

            var serviceAssemblies = Assembly.Load("Services");
            builder.RegisterAssemblyTypes(serviceAssemblies).AsImplementedInterfaces().InstancePerRequest();

            

            var repositoryAssemblies = Assembly.Load("PAFRepository");
            builder.RegisterAssemblyTypes(repositoryAssemblies)
                .AsImplementedInterfaces()
                .WithParameter(new NamedParameter("connectionString", connectionString))
                .InstancePerRequest();

            builder.RegisterType<PAFRepository.Repositories.LocalityRepository>()
                .As<PAFRepository.Interfaces.ILocalityRepository>()
                .WithParameter(new NamedParameter("connectionString", connectionString)).InstancePerRequest();

            var pafService = Assembly.Load("PAF.Services");
            builder.RegisterAssemblyTypes(pafService).AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterType<AddressService>();
            builder.RegisterFilterProvider();
        }
    }
}
