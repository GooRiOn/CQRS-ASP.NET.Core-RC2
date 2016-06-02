using CQRS.Infrastructure.Interfaces.Contracts;

namespace CQRS.Infrastructure.Interfaces.Handlers
{
    public interface ICommandHandler<in TCommand> where TCommand : class, ICommand
    {
        void Handle(TCommand command);
    }
}