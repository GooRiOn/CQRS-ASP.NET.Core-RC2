using System.Threading.Tasks;
using CQRS.Infrastructure.Interfaces.Contracts;
using System.Collections.Generic;

namespace CQRS.Infrastructure.Interfaces.Busses
{
    public interface IEventBus
    {
        void Send<TEvent>(TEvent @event) where TEvent : class, IEvent;
        void Send<TEvent>(IEnumerable<TEvent> events) where TEvent : class, IEvent;
        Task SendAsync<TEvent>(TEvent @event) where TEvent : class, IEvent;
    }
}