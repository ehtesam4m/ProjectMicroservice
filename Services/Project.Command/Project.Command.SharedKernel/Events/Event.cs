using System;

namespace Project.Command.SharedKernel.Events
{
    public class Event : IDomainEvent
    {
        public Guid AggregateId { get; protected set; }

        public Guid EventId { get; } = Guid.NewGuid();
        public int AggregateVersion { get; private set; }
        public DateTime OcurrendOn { get; } = DateTime.UtcNow;

        public void BuildVersion(int aggregateVersion)
        {
            AggregateVersion = aggregateVersion;
        }
    }
}
