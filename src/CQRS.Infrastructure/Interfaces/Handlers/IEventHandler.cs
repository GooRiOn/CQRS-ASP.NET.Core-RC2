
using CQRS.Infrastructure.Interfaces.Contracts;

namespace CQRS.Infrastructure.Interfaces.Handlers
{
    public interface IEventHandler<in TEvent> where TEvent : class, IEvent
    {
        void Handle(TEvent @event);
    }
}
