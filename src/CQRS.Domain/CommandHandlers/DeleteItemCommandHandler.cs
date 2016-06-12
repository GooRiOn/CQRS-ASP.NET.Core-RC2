using CQRS.Contracts.Commands;
using CQRS.Contracts.Events;
using CQRS.Domain.Aggregates;
using CQRS.Infrastructure.Interfaces.Busses;
using CQRS.Infrastructure.Interfaces.EventStore;
using CQRS.Infrastructure.Interfaces.Handlers;

namespace CQRS.Domain.CommandHandlers
{
    public class DeleteItemCommandHandler : ICommandHandler<DeleteItemCommand>
    {
        IEventStore EventStore { get; }
        IEventBus EventBus { get; }

        public DeleteItemCommandHandler(IEventStore eventStore, IEventBus eventBus)
        {
            EventStore = eventStore;
            EventBus = eventBus;
        }

        public void Handle(DeleteItemCommand command)
        {
            var itemEvents = EventStore.GetAggregateEvents<ItemBaseEvent>(command.Id);

            var item = new Item();

            item.LoadFromHistory(itemEvents);
            item.Delete();

            var uncommitedEvents = item.GetUncommittedEvents();

            foreach (var @event in uncommitedEvents)
                EventBus.Send(@event);
        }
    }
}
