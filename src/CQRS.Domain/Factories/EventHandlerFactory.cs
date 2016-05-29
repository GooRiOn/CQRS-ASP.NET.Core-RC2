using CQRS.Domain.Factories.Interfaces;
using CQRS.Domain.EventHandlers.Interfaces;
using CQRS.Contracts.Events.Interfaces;
using CQRS.Infrastructure.DependencyInjection.Interfaces;

namespace CQRS.Domain.Factories
{
    public class EventHandlerFactory : IEventHandlerFactory
    {
        ICustomDependencyResolver CustomDependencyResolver { get; }

        public EventHandlerFactory(ICustomDependencyResolver customDependencyResolver)
        {
            CustomDependencyResolver = customDependencyResolver;
        }

        public IEventHandler<TEvent> Get<TEvent>() where TEvent : class, IEvent =>
             CustomDependencyResolver.Resolve<IEventHandler<TEvent>>();
    }
}
