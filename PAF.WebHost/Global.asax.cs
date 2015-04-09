using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Autofac;
using Autofac.Integration.Wcf;

namespace PAF.WebHost
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            var builder = new ContainerBuilder();

            String connectionString = ConfigurationManager.ConnectionStrings["PAFContext"].ConnectionString;

            //var configurationManagerWrapperAssembly = Assembly.Load("ConfigurationManagerWrapper");
            //builder.RegisterAssemblyTypes(configurationManagerWrapperAssembly).AsImplementedInterfaces();

            var serviceAssemblies = Assembly.Load("Services");
            builder.RegisterAssemblyTypes(serviceAssemblies).AsImplementedInterfaces();



            var repositoryAssemblies = Assembly.Load("PAFRepository");
            builder.RegisterAssemblyTypes(repositoryAssemblies)
                .AsImplementedInterfaces()
                .WithParameter(new NamedParameter("connectionString", connectionString));

            builder.RegisterType<PAFRepository.Repositories.LocalityRepository>()
                .As<PAFRepository.Interfaces.ILocalityRepository>()
                .WithParameter(new NamedParameter("connectionString", connectionString));

            var pafService = Assembly.Load("PAF.Services");
            builder.RegisterAssemblyTypes(pafService);

            builder.RegisterType<PAF.Services.AddressService>();
            AutofacHostFactory.Container = builder.Build();

            //builder.RegisterFilterProvider();

            //var builder = new ContainerBuilder();
            //builder.RegisterType<AddressService>().As<IAddressService>();

            //AutofacHostFactory.Container = builder.Build();

            //IContainer container = null;
            //ContainerBuilder builder = new ContainerBuilder();

            //builder.RegisterAssemblyTypes(typeof (DeliveryPointService).Assembly)
            //    .Where(t => t.Name.EndsWith("Service"))
            //    .As(t => t.GetInterfaces().FirstOrDefault(
            //        i => i.Name == "I" + t.Name));

            //builder.RegisterAssemblyTypes(typeof (AddressService).Assembly)
            //    .AsImplementedInterfaces()
            //    .InstancePerRequest();
            //builder.RegisterType<AddressService>();

            //container = builder.Build();
            //AutofacHostFactory.Container = container;
            //ServiceHost host = new ServiceHost(typeof(AddressService));
            //host.AddDependencyInjectionBehavior(typeof(AddressService), container);

            //host.Open();
        }

       
    }
}