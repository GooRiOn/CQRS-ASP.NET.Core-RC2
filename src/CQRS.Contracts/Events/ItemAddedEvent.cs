using System;
using CQRS.Infrastructure.Interfaces.Contracts;

namespace CQRS.Contracts.Events
{
    public class ItemAddedEvent : IEvent
    {
        public Guid AggregateId { get; set; } 

        public string Name { get; set; }

        public int Quantity { get; set; }
    }
}