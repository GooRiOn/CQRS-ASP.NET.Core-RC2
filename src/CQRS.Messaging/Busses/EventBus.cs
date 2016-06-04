using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using CQRS.Contracts.Events;
using CQRS.Infrastructure.Interfaces.Busses;
using CQRS.Infrastructure.Interfaces.Contracts;
using CQRS.Infrastructure.Interfaces.DependencyInjection;
using CQRS.Infrastructure.Interfaces.Factories;
using CQRS.Infrastructure.Interfaces.Handlers;

namespace CQRS.Messaging.Busses
{
    public class EventBus : IEventBus
    {
        //TODO: Integration with RabbitMQ, Redis?

        IEventHandlerFactory EventHandlerFactory { get; }
        ICustomDependencyResolver test;

        public EventBus(IEventHandlerFactory eventHandlerFactory, ICustomDependencyResolver test1)
        {
            EventHandlerFactory = eventHandlerFactory;
            test = test1;
        }

        public void Send<TEvent>(TEvent @event) where TEvent : class, IEvent
        {
            var eventHandler = GetEventHandler(@event);
            eventHandler.Handle(@event);
        }

        public void Send<TEvent>(IEnumerable<TEvent> events) where TEvent : class, IEvent
        {
            foreach(var @event in events)
            {
                var eventHandler = GetEventHandler(@event);
                eventHandler.Handle(@event);
            }
        }

        public Task SendAsync<TEvent>(TEvent @event) where TEvent : class, IEvent
        {
            throw new System.NotImplementedException();
        }

        private IEventHandler<TEvent> GetEventHandler<TEvent>(TEvent @event) where TEvent : class, IEvent
        {
            var eventType = @event.GetType();
            var eventHandlerFactoryType = EventHandlerFactory.GetType();

            var eventHandler = (IEventHandler<TEvent>)eventHandlerFactoryType
                .GetMethod(nameof(IEventHandlerFactory.Get))
                .MakeGenericMethod(eventType)
                .Invoke(EventHandlerFactory, new object[] { });

            return eventHandler;
        }
    }
}