using CQRS.Contracts.Commands;
using CQRS.DataAccess;
using CQRS.Domain.Aggregates;
using CQRS.Domain.CommandHandlers.Interfaces;

namespace CQRS.Domain.CommandHandlers
{
    public class AddItemCommandHandler : ICommandHandler<AddItemCommand>
    {
        IInMemoryEventSotre EventSotre { get; }

        public AddItemCommandHandler(IInMemoryEventSotre eventStore)
        {
            EventSotre = eventStore;
        }

        public void Handle(AddItemCommand command)
        {
            var item = new Item(command.Id, command.Name, command.Quantity);
            item.Version = -1;

            EventSotre.Persist(item.GetUncommittedEvents());

            //send event to event bus
        }
    }
}