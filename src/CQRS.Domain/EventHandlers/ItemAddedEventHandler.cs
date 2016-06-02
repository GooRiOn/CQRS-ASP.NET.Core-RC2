using CQRS.Contracts.Events;
using CQRS.Infrastructure.Interfaces.Handlers;
using CQRS.Infrastructure.Interfaces.ReadSide;
using CQRS.Domain.Aggregates;

namespace CQRS.Domain.EventHandlers
{
    public class ItemAddedEventHandler : IEventHandler<ItemAddedEvent>
    {
        IInMemoryGenericRepo<Item> InMemoryRepo { get; }

        public ItemAddedEventHandler(IInMemoryGenericRepo<Item> inMemoryRepo)
        {
            InMemoryRepo = inMemoryRepo;
        }

        public void Handle(ItemAddedEvent @event)
        {
            //just for quick test, CANNOT INSERT AGGREGATES !!!

            InMemoryRepo.Insert(new Item(@event.AggregateId,@event.Name, @event.Quantity));
        }
    }
}
