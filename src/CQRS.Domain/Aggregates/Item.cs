using System;
using System.Collections.Generic;
using CQRS.Contracts.Commands;
using CQRS.Contracts.Events;
using CQRS.Infrastructure.Interfaces.Contracts;

namespace CQRS.Domain.Aggregates
{
    public class Item : AggregateRoot, IHandle<ItemAddedEvent>, IHandle<ItemUpdatedEvent>
    {
        public string Name { get; set; }

        public int Quantity { get; set; }

        public Item()
        {
            
        }

        public Item(Guid id, string name, int quantity)
        {
            var itemUpdatedEvent = new ItemAddedEvent
            {
                AggregateId = id,
                Name = name,
                Quantity = quantity
            };

            ApplyChange(itemUpdatedEvent);
            Events.Add(itemUpdatedEvent);
        }

        public void Update(string name, int quantity)
        {
            var itemUpdatedEvent = new ItemUpdatedEvent
            {
                AggregateId = Id,
                Name = name,
                Quantity = quantity
            };

            ApplyChange(itemUpdatedEvent);
            Events.Add(itemUpdatedEvent);
        }

        public void Delete()
        {
            Events.Add(new ItemDeletedEvent { AggregateId = Id });
        }

        public void Handle(ItemAddedEvent @event)
        {
            Id = @event.AggregateId;
            Name = @event.Name;
            Quantity = @event.Quantity;
        }

        public void Handle(ItemUpdatedEvent @event)
        {
            if (!string.IsNullOrEmpty(@event.Name))
                Name = @event.Name;

            if (@event.Quantity.HasValue)
                Quantity = @event.Quantity.Value;
        }
    }
}
