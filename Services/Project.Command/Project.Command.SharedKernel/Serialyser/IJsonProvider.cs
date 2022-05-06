namespace Project.Command.SharedKernel.Serialyser
{
    public interface IJsonProvider
    {
        string SerializeObject<TEvent>(TEvent domainEvent);
    }
}
