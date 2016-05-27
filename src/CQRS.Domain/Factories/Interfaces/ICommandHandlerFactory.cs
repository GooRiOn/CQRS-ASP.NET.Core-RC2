using CQRS.Contracts.Commands.Interfaces;
using CQRS.Domain.CommandHandlers.Interfaces;

namespace CQRS.Domain.Factories.Interfaces
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<TCommand> Get<TCommand>() where TCommand : class, ICommand;
    }
}