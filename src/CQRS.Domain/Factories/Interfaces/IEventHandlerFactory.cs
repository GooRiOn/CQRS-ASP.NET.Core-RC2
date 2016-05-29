using CQRS.Contracts.Events.Interfaces;
using CQRS.Domain.EventHandlers.Interfaces;

namespace CQRS.Domain.Factories.Interfaces
{
    public interface IEventHandlerFactory
    {
        IEventHandler<TEvent> Get<TEvent>() where TEvent : class, IEvent;
    }
}
