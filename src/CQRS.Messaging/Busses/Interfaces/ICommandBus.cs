using System.Threading.Tasks;
using CQRS.Contracts.Commands.Interfaces;

namespace CQRS.Messaging.Busses.Interfaces
{
    public interface ICommandBus
    {
        void Send<TCommand>(TCommand command) where TCommand : class, ICommand;
        Task SendAsync<TCommand>(TCommand command) where TCommand : class, ICommand;
    }
}