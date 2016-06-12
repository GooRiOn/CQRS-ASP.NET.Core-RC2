using Autofac;
using CQRS.Contracts.Commands;
using CQRS.Contracts.Events;
using CQRS.Domain.CommandHandlers;
using CQRS.Domain.EventHandlers;
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

            containerBuilder.RegisterType<EventHandlerExecutor>().As<IEventHandlerExecutor>();

            containerBuilder.RegisterType<ItemAddedEventHandler>().As<IEventHandler<ItemAddedEvent>>();

            containerBuilder.RegisterType<ItemDeletedEventHandler>().As<IEventHandler<ItemDeletedEvent>>();



            containerBuilder.RegisterType<CommandHandlerFactory>().As<ICommandHandlerFactory>();           

            containerBuilder.RegisterType<AddItemCommandHandler>().As<ICommandHandler<AddItemCommand>>();

            containerBuilder.RegisterType<DeleteItemCommandHandler>().As<ICommandHandler<DeleteItemCommand>>();
        }
    }
}