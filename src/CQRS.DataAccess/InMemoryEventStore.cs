using System.Collections.Generic;
using System;
using CQRS.Infrastructure.Interfaces.Contracts;

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
