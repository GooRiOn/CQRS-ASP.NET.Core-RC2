using System.Threading.Tasks;
using CQRS.Infrastructure.Interfaces.Contracts;


namespace CQRS.Infrastructure.Interfaces.Busses
{
    public interface ICommandBus
    {
        void Send<TCommand>(TCommand command) where TCommand : class, ICommand;
        Task SendAsync<TCommand>(TCommand command) where TCommand : class, ICommand;
    }
}