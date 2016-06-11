using System;
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

        IEventHandlerExecutor EventHandlerExecutor { get; }
        ICustomDependencyResolver test;

        public EventBus(IEventHandlerExecutor eventHandlerExecutor, ICustomDependencyResolver test1)
        {
            EventHandlerExecutor = eventHandlerExecutor;
            test = test1;
        }

        public void Send<TEvent>(TEvent @event) where TEvent : class, IEvent
        {
            var eventType = @event.GetType();
            var eventHandlerFactoryType = EventHandlerExecutor.GetType();

            eventHandlerFactoryType
            .GetMethod(nameof(IEventHandlerExecutor.Execute))
            .MakeGenericMethod(eventType)
            .Invoke(EventHandlerExecutor, new object[] { @event});
        }
       
        public Task SendAsync<TEvent>(TEvent @event) where TEvent : class, IEvent
        {
            throw new System.NotImplementedException();
        }
    }
}