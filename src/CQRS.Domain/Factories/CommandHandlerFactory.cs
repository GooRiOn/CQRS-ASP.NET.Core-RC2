using CQRS.Infrastructure.DependencyInjection.Interfaces.DependencyInjection;
using CQRS.Infrastructure.Interfaces.Contracts;
using CQRS.Infrastructure.Interfaces.Factories;
using CQRS.Infrastructure.Interfaces.Handlers;

namespace CQRS.Domain.Factories
{
    public class CommandHandlerFactory : ICommandHandlerFactory
    { 
        ICustomDependencyResolver CustomDependencyResolver { get; }

        public CommandHandlerFactory(ICustomDependencyResolver customDependencyResolver)
        {
            CustomDependencyResolver = customDependencyResolver;
        }

        public ICommandHandler<TCommand> Get<TCommand>() where TCommand : class, ICommand
    
        {
            return CustomDependencyResolver.Resolve<ICommandHandler<TCommand>>();
        }
    }
}