using CQRS.Infrastructure.Interfaces.Contracts;
using CQRS.Infrastructure.Interfaces.Handlers;

namespace CQRS.Infrastructure.Interfaces.Factories
{
    public interface IEventHandlerExecutor
    {
        void Execute<TEvent>(TEvent @event) where TEvent : class, IEvent;
    }
}
