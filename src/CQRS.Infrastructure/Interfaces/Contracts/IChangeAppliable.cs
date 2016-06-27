namespace CQRS.Infrastructure.Interfaces.Contracts
{
    public interface IChangeAppliable<in TEvent> where TEvent : class, IEvent
    {
        void ApplyChange(TEvent @event);
    }
}