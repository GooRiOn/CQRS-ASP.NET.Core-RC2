using CQRS.Infrastructure.DependencyInjection.Interfaces.DependencyInjection;
using CQRS.Infrastructure.Interfaces.Contracts;
using CQRS.Infrastructure.Interfaces.Factories;
using CQRS.Infrastructure.Interfaces.Handlers;

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
