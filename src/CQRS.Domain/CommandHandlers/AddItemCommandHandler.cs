using CQRS.Contracts.Commands;
using CQRS.DataAccess;
using CQRS.Domain.Aggregates;
using CQRS.Infrastructure.Interfaces.Busses;
using CQRS.Infrastructure.Interfaces.Handlers;
using System.Linq;

namespace CQRS.Domain.CommandHandlers
{
    public class AddItemCommandHandler : ICommandHandler<AddItemCommand>
    {
        IInMemoryEventSotre EventSotre { get; }
        IEventBus EventBus { get; }
 
        public AddItemCommandHandler(IInMemoryEventSotre eventStore, IEventBus eventBus)
        {
            EventSotre = eventStore;
            EventBus = eventBus;
        }

        public void Handle(AddItemCommand command)
        {
            var item = new Item(command.Id, command.Name, command.Quantity);
            item.Version = -1;

            EventSotre.Persist(item.GetUncommittedEvents());

            var uncommittedEvent = item.GetUncommittedEvents().FirstOrDefault() ;

            EventBus.Send(uncommittedEvent);
        }
    }
}