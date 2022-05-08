using Project.Command.Domain.EventSourcing;
using Project.Command.SharedKernel.Events;
using System.Collections.Generic;

namespace Project.Command.Infrastructure
{
    public interface IDomainEventRebuilder
    {
        IEnumerable<Event> RebuildDomainEvents(IEnumerable<EventStore> eventStoreItems);
    }
}