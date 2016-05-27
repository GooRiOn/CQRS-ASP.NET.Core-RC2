using CQRS.Contracts.Commands.Interfaces;
using CQRS.Domain.CommandHandlers.Interfaces;

namespace CQRS.Domain.Factories.Interfaces
{
    public interface ICommandHandlerFactory<in TCommand> where TCommand : class, ICommand
    {
        ICommandHandler<TCommand> Get(TCommand command);
    }
}