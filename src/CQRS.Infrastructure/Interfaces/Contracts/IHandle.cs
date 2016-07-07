namespace CQRS.Infrastructure.Interfaces.Contracts
{
    public interface IHandle<in TEvent> where TEvent : class, IEvent
    {
        void Handle(TEvent @event);
    }
}