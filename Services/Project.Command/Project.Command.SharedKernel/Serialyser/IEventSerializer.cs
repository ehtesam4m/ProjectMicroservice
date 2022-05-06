using Project.Command.SharedKernel.Events;

namespace Project.Command.SharedKernel.Serialyser
{
    public interface IEventSerializer
    {
        string Serialize<TEvent>(TEvent domainEvent) where TEvent : IDomainEvent;
    }
}
