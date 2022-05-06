using System;

namespace Project.Command.SharedKernel.Events
{
    public class ProjectCreatedEvent : Event
    {
        public string Name { get; }
        public string ClientName { get;}
        public ProjectCreatedEvent(Guid aggregateId, string name, string clientName)
        {
            AggregateId = aggregateId;
            Name = name;
            ClientName = clientName;
        }
    }

}
