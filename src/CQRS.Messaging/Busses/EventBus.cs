using CQRS.Infrastructure.Interfaces.Busses;
using CQRS.Infrastructure.Interfaces.Contracts;
using CQRS.Infrastructure.Interfaces.Factories;
using System.Threading.Tasks;

namespace CQRS.Messaging.Busses
{
    public class EventBus : IEventBus
    {
        //TODO: Integration with RabbitMQ, Redis?

        IEventHandlerFactory EventHandlerFactory { get; }

        public EventBus(IEventHandlerFactory eventHandlerFactory)
        {
            EventHandlerFactory = eventHandlerFactory;
        }

        public void Send<TEvent>(TEvent @event) where TEvent : class, IEvent
        {
            var eventHandler = EventHandlerFactory.Get<TEvent>();

            eventHandler.Handle(@event);
        }

        public Task SendAsync<TEvent>(TEvent @event) where TEvent : class, IEvent
        {
            throw new System.NotImplementedException();
        }
    }
}