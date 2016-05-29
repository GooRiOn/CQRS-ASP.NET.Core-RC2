using Autofac;
using CQRS.Contracts.Commands;
using CQRS.Domain.CommandHandlers;
using CQRS.Domain.CommandHandlers.Interfaces;
using CQRS.Domain.Factories;
using CQRS.Domain.Factories.Interfaces;

namespace CQRS.Domain.DependencyInjection
{
    public class Registration : Module
    {
        public static void Register(ContainerBuilder containerBuilder)
        {
            DataAccess.DependencyInjection.Registration.Register(containerBuilder);

            containerBuilder.RegisterType<CommandHandlerFactory>().As<ICommandHandlerFactory>();

            containerBuilder.RegisterType<AddItemCommandHandler>().As<ICommandHandler<AddItemCommand>>();

        }
    }
}