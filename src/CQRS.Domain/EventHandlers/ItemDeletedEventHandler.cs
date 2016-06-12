using CQRS.Contracts.Events;
using CQRS.Infrastructure.Interfaces.Handlers;
using CQRS.ReadSide.Repositories.Interfaces;

namespace CQRS.Domain.EventHandlers
{
    public class ItemDeletedEventHandler : IEventHandler<ItemDeletedEvent>
    {
        IItemRepository ItemRepository { get; }

        public ItemDeletedEventHandler(IItemRepository itemRepository)
        {
            ItemRepository = itemRepository;
        }

        public void Handle(ItemDeletedEvent @event)
        {
            var item = ItemRepository.GetById(@event.AggregateId);

            ItemRepository.SoftDelete(item);
            ItemRepository.Commit();
        }
    }
}