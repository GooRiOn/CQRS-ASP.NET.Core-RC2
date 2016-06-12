using CQRS.Contracts.Events;
using CQRS.Infrastructure.Interfaces.Handlers;
using CQRS.Infrastructure.Interfaces.ReadSide;
using CQRS.ReadSide.Entities;
using CQRS.ReadSide.Repositories.Interfaces;

namespace CQRS.Domain.EventHandlers
{
    public class ItemAddedEventHandler : IEventHandler<ItemAddedEvent>
    {
        IItemRepository ItemRepository { get; }

        public ItemAddedEventHandler(IItemRepository itemRepository)
        {
            ItemRepository = itemRepository;
        }

        public void Handle(ItemAddedEvent @event)
        {
            var itemRepository = ((IGenericRepository<ItemEntity>)ItemRepository);

            itemRepository.Add(new ItemEntity
            {
                Id = @event.AggregateId,
                Name = @event.Name,
                Quantity = @event.Quantity
            });

            itemRepository.Commit();
        }
    }
}
