using CQRS.Contracts.Events;
using CQRS.Infrastructure.Interfaces.Handlers;
using CQRS.ReadSide.Repositories.Interfaces;

namespace CQRS.Domain.EventHandlers
{
    public class ItemUpdatedEventHandler : IEventHandler<ItemUpdatedEvent>
    {
        IItemRepository ItemRepository { get; }

        public ItemUpdatedEventHandler(IItemRepository itemRepository)
        {
            ItemRepository = itemRepository;
        }

        public void Handle(ItemUpdatedEvent @event)
        {
            var item = ItemRepository.GetById(@event.AggregateId);

            item.Name = @event.Name;

            if(@event.Quantity.HasValue)
                item.Quantity = @event.Quantity.Value;

            ItemRepository.Commit();
        }
    }
}