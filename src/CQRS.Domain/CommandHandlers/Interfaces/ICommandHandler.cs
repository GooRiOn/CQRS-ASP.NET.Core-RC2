using CQRS.Contracts.Commands.Interfaces;

namespace CQRS.Domain.CommandHandlers.Interfaces
{
    public interface ICommandHandler<in TCommand> where TCommand : class, ICommand
    {
        void Handle(TCommand command);
    }
}