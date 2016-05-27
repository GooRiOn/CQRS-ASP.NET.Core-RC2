using CQRS.Contracts.Commands.Interfaces;
using CQRS.Domain.CommandHandlers.Interfaces;
using CQRS.Domain.Factories.Interfaces;
using CQRS.Infrastructure.DependencyInjection.Interfaces;

namespace CQRS.Domain.Factories
{
    public class CommandHandlerFactory<TCommand> : ICommandHandlerFactory<TCommand> where TCommand : class, ICommand
    {
        ICustomDependencyResolver CustomDependencyResolver { get; }

        public CommandHandlerFactory(ICustomDependencyResolver customDependencyResolver)
        {
            CustomDependencyResolver = customDependencyResolver;
        }

        public ICommandHandler<TCommand> Get(TCommand command)
        {
            return CustomDependencyResolver.Resolve<ICommandHandler<TCommand>>();
        }
    }
}