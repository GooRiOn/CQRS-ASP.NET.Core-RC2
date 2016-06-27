using System;
using System.Collections.Generic;
using CQRS.Contracts.Events;
using CQRS.Infrastructure.Interfaces.Contracts;

namespace CQRS.Domain.Aggregates
{
    public class Item : AggregateRoot, IChangeAppliable<ItemAddedEvent>, IChangeAppliable<ItemUpdatedEvent>
    {
        public string Name { get; set; }

        public int Quantity { get; set; }

        public Item()
        {
            
        }

        public Item(Guid id, string name, int quantity)
        {
            Id = id;
            Name = name;
            Quantity = quantity;

            Events.Add(new ItemAddedEvent
            {
                AggregateId = id,
                Name = name,
                Quantity = quantity
            });            
        }

        public void Delete()
        {
            Events.Add(new ItemDeletedEvent {AggregateId = Id});
        }

        //public override void LoadFromHistory(IEnumerable<IEvent> events)
        //{
        //    foreach (var @event in events)
        //    {
        //        ItemAddedEvent itemAddedEvent;
        //        ItemUpdatedEvent itemUpdatedEvent;
        //        ItemDeletedEvent itemDeletedEvent;

        //        if ((itemAddedEvent = @event as ItemAddedEvent) != null)
        //        {
        //            Id = itemAddedEvent.AggregateId;
        //            Name = itemAddedEvent.Name;
        //            Quantity = itemAddedEvent.Quantity;
        //        }
        //        else if ((itemUpdatedEvent = @event as ItemUpdatedEvent) != null)
        //        {
        //            Id = itemUpdatedEvent.AggregateId;

        //            if (!string.IsNullOrEmpty(itemUpdatedEvent.Name))
        //                Name = itemUpdatedEvent.Name;

        //            if (itemUpdatedEvent.Quantity.HasValue)
        //                Quantity = itemUpdatedEvent.Quantity.Value;
        //        }
        //        else if ((itemDeletedEvent = @event as ItemDeletedEvent) != null)
        //        {
        //            throw new InvalidOperationException("Aggregate deleted");
        //        }
        //    }
        //}

        public void ApplyChange(ItemAddedEvent @event)
        {
            Id = @event.AggregateId;
            Name = @event.Name;
            Quantity = @event.Quantity;
        }

        public void ApplyChange(ItemUpdatedEvent @event)
        {
            if (!string.IsNullOrEmpty(@event.Name))
                Name = @event.Name;

            if (@event.Quantity.HasValue)
                Quantity = @event.Quantity.Value;
        }
    }
}
