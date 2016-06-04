using System;
using System.Collections.Generic;
using CQRS.Contracts.Events;
using CQRS.Infrastructure.Interfaces.Contracts;

namespace CQRS.Domain.Aggregates
{
    public class Item : AggregateRoot
    {
        public string Name { get; set; }

        public int Quantity { get; set; }

        public Item(Guid id, string name, int quantity)
        {
            Events.Add(new ItemAddedEvent
            {
                AggregateId = id,
                Name = name,
                Quantity = quantity
            });            
        }

        public override void LoadFromHistory(IEnumerable<IEvent> events)
        {
            throw new NotImplementedException();
        }
    }
}
