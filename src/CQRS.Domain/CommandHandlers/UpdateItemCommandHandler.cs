using CQRS.Contracts.Commands;
using CQRS.Contracts.Events;
using CQRS.Domain.Aggregates;
using CQRS.Infrastructure.Interfaces.Busses;
using CQRS.Infrastructure.Interfaces.EventStore;
using CQRS.Infrastructure.Interfaces.Handlers;

namespace CQRS.Domain.CommandHandlers
{
    public class UpdateItemCommandHandler : ICommandHandler<UpdateItemCommand>
    {
        IEventStore EventStore { get; }
        IEventBus EventBus { get; }

        public UpdateItemCommandHandler(IEventStore eventStore, IEventBus eventBus)
        {
            EventStore = eventStore;
            EventBus = eventBus;
        }

        public void Handle(UpdateItemCommand command)
        {
            var itemEvents = EventStore.GetAggregateEvents<ItemBaseEvent>(command.Id);
            var item = new Item();

            item.LoadFromHistory(itemEvents);
            item.Update(command.Name, command.Quantity);

            var events = item.GetUncommittedEvents();

            EventStore.Persist(events);

            foreach (var @event in events)
                EventBus.Send(@event);
        }
    }
}