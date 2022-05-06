using Project.Command.SharedKernel.Events;
using System.Collections.Generic;

namespace Project.Command.Domain.EventSourcing
{
    public interface IEventSourcing
    {
        //version should be readonly
        int Version { get; set; }

        void ValidateVersion(int expectedVersion);

        IEnumerable<IDomainEvent> GetUncommittedEvents();

        void ClearUncommittedEvents();
    }
}
