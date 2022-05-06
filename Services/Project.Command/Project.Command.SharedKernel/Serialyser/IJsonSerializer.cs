namespace Project.Command.SharedKernel.Serialyser
{
    public interface IJsonSerializer
    {
        string Serialize<T>(T objectValue);
    }
}
