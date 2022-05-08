using Project.Command.Domain.EventSourcing;
using System.Threading.Tasks;

namespace Project.Command.Application.Common.Interfaces
{
    public interface IEventStoreRepository
    {
        Task AppendAsync(EventStore @event);
    }
}
