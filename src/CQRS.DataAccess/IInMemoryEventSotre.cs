using System.Collections.Generic;
using CQRS.Infrastructure.Interfaces.Contracts;

namespace CQRS.DataAccess
{
    public interface IInMemoryEventSotre
    {
        void Persist(IEnumerable<IEvent> events);
    }
}