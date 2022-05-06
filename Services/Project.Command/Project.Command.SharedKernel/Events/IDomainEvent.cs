using System;

namespace Project.Command.SharedKernel.Events
{
    public interface IDomainEvent
    {
        Guid EventId { get; }
        int AggregateVersion { get; }

        void BuildVersion(int aggregateVersion);
    }
}
