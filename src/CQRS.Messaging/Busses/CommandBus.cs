using System.Threading.Tasks;
using CQRS.Contracts.Commands.Interfaces;
using CQRS.Domain.Factories.Interfaces;
using CQRS.Messaging.Busses.Interfaces;

namespace CQRS.Messaging.Busses
{
    public class CommandBus : ICommandBus
    {
        //TODO: Integrate with RabbitMQ, Redis?

        ICommandHandlerFactory CommandHandlerFactory { get; }

        public CommandBus(ICommandHandlerFactory commandHandlerFactory)
        {
            CommandHandlerFactory = commandHandlerFactory;
        }

        public void Send<TCommand>(TCommand command) where TCommand : class, ICommand
        {
            var commandHandler = CommandHandlerFactory.Get<TCommand>();

            commandHandler.Handle(command);
        }

        public async Task SendAsync<TCommand>(TCommand command) where TCommand : class, ICommand
        {
            throw new System.NotImplementedException();
        }
    }
}