using Autofac;
using CQRS.Messaging.Busses;
using CQRS.Messaging.Busses.Interfaces;

namespace CQRS.Messaging.DependencyInjection
{
    public class Registration : Module
    {
        public static void Register(ContainerBuilder containerBuilder)
        {
            Domain.DependencyInjection.Registration.Register(containerBuilder);

            containerBuilder.RegisterType<CommandBus>().As<ICommandBus>().SingleInstance();
        } 
    }
}