using System;
using System.Collections.Generic;
using CQRS.Infrastructure.Interfaces.Contracts;

namespace CQRS.Infrastructure.Interfaces.EventStore
{
    public interface IEventStore
    {
        void Persist(IEnumerable<IEvent> events);
        IEnumerable<IEvent> GetAggregateEvents<TEvent>(Guid id) where TEvent : class, IEvent;
    }
}