using CQRS.Infrastructure.Interfaces.Contracts;
using CQRS.Infrastructure.Interfaces.DependencyInjection;
using CQRS.Infrastructure.Interfaces.Factories;
using CQRS.Infrastructure.Interfaces.Handlers;

namespace CQRS.Domain.Factories
{
    public class EventHandlerExecutor : IEventHandlerExecutor
    {
        ICustomDependencyResolver CustomDependencyResolver { get; }

        public EventHandlerExecutor(ICustomDependencyResolver customDependencyResolver)
        {
            CustomDependencyResolver = customDependencyResolver;
        }

        public void Execute<TEvent>(TEvent @event) where TEvent : class, IEvent =>
             CustomDependencyResolver.Resolve<IEventHandler<TEvent>>().Handle(@event);
    }
}
