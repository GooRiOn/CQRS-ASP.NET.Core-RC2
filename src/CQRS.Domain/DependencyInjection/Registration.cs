using Autofac;
using CQRS.Domain.Factories;
using CQRS.Domain.Factories.Interfaces;

namespace CQRS.Domain.DependencyInjection
{
    public class Registration : Module
    {
        public static void Register(ContainerBuilder containerBuilder)
        {
            CQRS.DataAccess.DependencyInjection.Registration.Register(containerBuilder);

            containerBuilder.RegisterType<CommandHandlerFactory>().As<ICommandHandlerFactory>();
        }
    }
}