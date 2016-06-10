using CQRS.Infrastructure.Interfaces.Contracts;
using System;
using System.ComponentModel.DataAnnotations;


namespace CQRS.Contracts.Events
{
    public class ItemBaseEvent : IEvent
    {       
        public Guid AggregateId { get; set; }
    }
}
