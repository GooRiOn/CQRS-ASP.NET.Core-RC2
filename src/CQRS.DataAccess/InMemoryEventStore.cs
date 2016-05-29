using System.Collections.Generic;
using CQRS.Contracts.Events.Interfaces;
using System;

namespace CQRS.DataAccess
{
    public class InMemoryEventStore : IInMemoryEventSotre
    {
        List<IEvent> Events { get; } = new List<IEvent>();
      
        public void Persist(IEnumerable<IEvent> events)
        {
            Events.AddRange(events);
            Console.WriteLine("Events persisted");
        }
    }
}
