using Project.Command.Domain.Entities;
using Project.Command.Domain.EventSourcing;
using Project.Command.Domain.Exceptions;
using Project.Command.SharedKernel.Events;
using System.Collections.Generic;
using System.Linq;

namespace Project.Command.Domain.Aggerates
{
    public abstract class AggregateRoot<T> : Entity<T>, IEventSourcing
    {
        public int Version { get; set; }
        private readonly ICollection<IDomainEvent> _uncommittedEvents = new LinkedList<IDomainEvent>();

        protected AggregateRoot()
        {
        }

        public void ValidateVersion(int expectedVersion)
        {
            if (Version != expectedVersion)
            {
                throw new ConcurrencyException($"Invalid version specified expectedVersion = {expectedVersion} is not equals to aggregateVersion");
            }
        }

        public void ApplyEvent(IDomainEvent @event, int version)
        {
            if (!_uncommittedEvents.Any(x => Equals(x.EventId, @event.EventId)))
            {
                ((dynamic)this).Apply((dynamic)@event);
                Version = version;
            }
        }

        public IEnumerable<IDomainEvent> GetUncommittedEvents()
        {
            return _uncommittedEvents.AsEnumerable();
        }

        public void ClearUncommittedEvents()
        {
            _uncommittedEvents.Clear();
        }

        protected void AddDomainEvent(IDomainEvent @event, int originalVersion = -1)
        {
            ValidateVersion(originalVersion);
            @event.BuildVersion(Version + 1);
            ApplyEvent(@event, @event.AggregateVersion);
            _uncommittedEvents.Add(@event);
        }
    }
}
