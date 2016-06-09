using CQRS.Infrastructure.Interfaces.Contracts;
using System;
using System.ComponentModel.DataAnnotations;


namespace CQRS.Contracts.Events
{
    public class ItemBaseEvent : IEvent
    {
        [Key]
        public Guid AggregateId { get; set; }
    }
}
