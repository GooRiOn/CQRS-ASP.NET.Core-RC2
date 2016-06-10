namespace CQRS.Contracts.Events
{
    public class ItemUpdatedEvent : ItemBaseEvent
    {
        public string Name { get; set; }

        public int Quantity { get; set; }
    }
}
