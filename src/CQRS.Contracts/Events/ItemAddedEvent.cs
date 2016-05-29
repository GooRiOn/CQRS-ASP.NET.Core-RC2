using System;
using CQRS.Contracts.Events.Interfaces;

namespace CQRS.Contracts.Events
{
    public class ItemAddedEvent : IEvent
    {
        public Guid AggregateId { get; set; } 

        public string Name { get; set; }

        public int Quantity { get; set; }
    }
}