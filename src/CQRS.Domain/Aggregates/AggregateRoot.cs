using System;
using System.Collections.Generic;
using CQRS.Contracts.Events.Interfaces;

namespace CQRS.Domain.Aggregates
{
    public abstract class AggregateRoot
    {
        public Guid Id { get; set; }

        public int Version { get; set; }

        protected List<IEvent> Events { get; set; } = new List<IEvent>();

        public IEnumerable<IEvent> GetUncommittedEvents() => Events;

        public void MarkEventsAsCommitted() => Events.Clear();

        public abstract void LoadFromHistory(IEnumerable<IEvent> events);

    }
}
