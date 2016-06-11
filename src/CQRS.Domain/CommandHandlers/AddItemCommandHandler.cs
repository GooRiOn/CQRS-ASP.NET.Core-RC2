using System.Collections.Generic;
using CQRS.Contracts.Commands;
using CQRS.Contracts.Events;
using CQRS.Domain.Aggregates;
using CQRS.Infrastructure.Interfaces.Busses;
using CQRS.Infrastructure.Interfaces.Handlers;
using System.Linq;
using CQRS.Infrastructure.Interfaces.EventStore;

namespace CQRS.Domain.CommandHandlers
{
    public class AddItemCommandHandler : ICommandHandler<AddItemCommand>
    {
        IEventStore EventSotre { get; }
        IEventBus EventBus { get; }
 
        public AddItemCommandHandler(IEventStore eventStore, IEventBus eventBus)
        {
            EventSotre = eventStore;
            EventBus = eventBus;
        }

        public void Handle(AddItemCommand command)
        {
            var item = new Item(command.Id, command.Name, command.Quantity)
            {
                Version = -1
            };

            var events = item.GetUncommittedEvents();

            EventSotre.Persist(events);

            foreach (var @event in events)
            {
                var itemEvent = @event;
                EventBus.Send(itemEvent);
            }
        }
    }
}