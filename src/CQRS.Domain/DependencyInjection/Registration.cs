using Autofac;
using CQRS.Contracts.Commands;
using CQRS.Domain.CommandHandlers;
using CQRS.Domain.Factories;
using CQRS.Infrastructure.Interfaces.Factories;
using CQRS.Infrastructure.Interfaces.Handlers;

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