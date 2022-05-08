using Project.Command.Domain.EventSourcing;
using Project.Command.SharedKernel.Events;
using Project.Command.SharedKernel.Serialyser;
using System.Collections.Generic;
using System.Linq;

namespace Project.Command.Infrastructure
{
    public class DomainEventRebuilder : IDomainEventRebuilder
    {
        private readonly IEventSerializer _eventSerializer;

        public DomainEventRebuilder(IEventSerializer eventSerializer)
        {
            _eventSerializer = eventSerializer;
        }

        public IEnumerable<Event> RebuildDomainEvents(IEnumerable<EventStore> eventStoreItems)
        {
            var events = eventStoreItems.Select(@event => _eventSerializer.Deserialize<Event>(@event.TypeName, @event.PayLoad)).AsEnumerable();
            return events;
        }
    }
}