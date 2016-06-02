using CQRS.Infrastructure.Interfaces.Contracts;
using CQRS.Infrastructure.Interfaces.Handlers;

namespace CQRS.Infrastructure.Interfaces.Factories
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<TCommand> Get<TCommand>() where TCommand : class, ICommand;
    }
}