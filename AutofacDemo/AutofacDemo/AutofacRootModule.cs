
using Autofac;

using AutofacDemo.Services;

namespace AutofacDemo
{
    public class AutofacRootModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // The generic ILogger<TCategoryName> service was added to the ServiceCollection by ASP.NET Core.
            // It was then registered with Autofac using the Populate method. All of this starts
            // with the services.AddAutofac() that happens in Program and registers Autofac
            // as the service provider.
            builder.RegisterType<CreatedOnDateTimeService>().As<ISingletonService>().SingleInstance();
            builder.RegisterType<CreatedOnDateTimeService>().As<IScopedService>().InstancePerLifetimeScope();
            builder.RegisterType<CreatedOnDateTimeService>().As<ITransientService>().InstancePerDependency();
        }
    }
}
