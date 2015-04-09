using System;
using System.Configuration;
using System.Reflection;
using Autofac;
using Autofac.Integration.Wcf;
using PAFRepository.Repositories;

namespace PAF.Services
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
                .WithParameter(new NamedParameter("connectionString", connectionString))
               ;

            builder.RegisterType<LocalityRepository>()
                .As<PAFRepository.Interfaces.ILocalityRepository>()
                .WithParameter(new NamedParameter("connectionString", connectionString));

            var pafService = Assembly.Load("PAF.Services");
            builder.RegisterAssemblyTypes(pafService).AsImplementedInterfaces();

            builder.RegisterType<AddressService>().AsSelf();

            AutofacHostFactory.Container = builder.Build();

            //IContainer container = null;
            //var builder = new ContainerBuilder();

            //builder.RegisterAssemblyTypes(typeof(LocalityService).Assembly)
            //    .Where(t => t.Name.EndsWith("Service"))
            //    .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            //builder.RegisterType<AddressService>();
            ////builder.RegisterType<ThoroughFareService>();
            ////builder.RegisterType<DeliveryPointService>();

            //AutofacHostFactory.Container = builder.Build();

            //ServiceHost serviceHost = new ServiceHost(typeof(LocalityService));
            
            //serviceHost.AddDependencyInjectionBehavior(typeof(LocalityService), container);

            //serviceHost.Open();

            //serviceHost.Close();
            //IKernel kernel = new StandardKernel(new MyNinjectModule());

            //NinjectServiceHost serviceHost = new NinjectServiceHost(kernel.Get<IServiceBehavior>(), typeof(MyNinjectModule));
            // serviceHost.Open();

        }

    }
}