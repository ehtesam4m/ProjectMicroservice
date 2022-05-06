using System;

namespace Project.Command.Domain.EventSourcing
{
    public class EventStore
    {
        public int Id { get; set; }
        public int Version { get; set; }
        public Guid AggregateId { get; set; }
        public string Name { get; set; }
        public string TypeName { get; set; }
        public DateTime OccurredOn { get; set; }
        public string PayLoad { get; set; }

        private EventStore()
        {
        }

        public EventStore(Guid aggregateId, int aggregateVersion, string name, string typeName, DateTime occurredOn, string serializedBody)
        {
            Version = aggregateVersion;
            AggregateId = aggregateId;
            Name = name;
            TypeName = typeName;
            OccurredOn = occurredOn;
            PayLoad = serializedBody;
        }
    }
}
