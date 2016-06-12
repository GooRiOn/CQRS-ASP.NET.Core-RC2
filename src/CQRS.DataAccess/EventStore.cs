using System;
using System.Collections.Generic;
using System.Reflection;
using CQRS.Infrastructure.Interfaces.Contracts;
using CQRS.Infrastructure.Interfaces.EventStore;
using System.Linq;

namespace CQRS.DataAccess
{
    public class EventStore : IEventStore
    {
        WriteContext Context { get; }

        public EventStore(WriteContext context)
        {
            Context = context;
        }

        public void Persist(IEnumerable<IEvent> events)
        {
            foreach (var @event in events)
            {
                var eventType = @event.GetType();

                var genericSetMethod = typeof(WriteContext).GetMethods().First(m => m.Name == "Set" && m.IsGenericMethod);

                var dbSet = genericSetMethod.MakeGenericMethod(eventType).Invoke(Context, null);

                dbSet.GetType().GetMethod("Add").Invoke(dbSet, new [] { @event });
            }

            Context.SaveChanges();
        }

        public IEnumerable<IEvent> GetAggregateEvents<TEvent>(Guid id) where TEvent : class, IEvent
        {
            return Context.Set<TEvent>().Where(e => e.AggregateId == id).ToList();
        }
    }
}
