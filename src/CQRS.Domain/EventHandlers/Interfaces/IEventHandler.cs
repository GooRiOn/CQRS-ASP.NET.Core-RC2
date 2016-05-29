using CQRS.Contracts.Events.Interfaces;

namespace CQRS.Domain.EventHandlers.Interfaces
{
    public interface IEventHandler<in TEvent> where TEvent : class, IEvent
    {
        void Handle(TEvent @event);
    }
}
