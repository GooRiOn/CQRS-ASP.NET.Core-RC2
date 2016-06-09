using System;
using CQRS.Infrastructure.Interfaces.Contracts;

namespace CQRS.Contracts.Events
{
    public class ItemAddedEvent : ItemBaseEvent
    {       

        public string Name { get; set; }

        public int Quantity { get; set; }
    }
}