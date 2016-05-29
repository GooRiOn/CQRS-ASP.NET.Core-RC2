using System.Collections.Generic;
using CQRS.Contracts.Events.Interfaces;

namespace CQRS.DataAccess
{
    public interface IInMemoryEventSotre
    {
        void Persist(IEnumerable<IEvent> events);
    }
}