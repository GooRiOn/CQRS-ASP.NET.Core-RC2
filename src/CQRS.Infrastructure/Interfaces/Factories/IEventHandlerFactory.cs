using CQRS.Infrastructure.Interfaces.Contracts;
using CQRS.Infrastructure.Interfaces.Handlers;

namespace CQRS.Infrastructure.Interfaces.Factories
{
    public interface IEventHandlerFactory
    {
        IEventHandler<TEvent> Get<TEvent>() where TEvent : class, IEvent;
    }
}
