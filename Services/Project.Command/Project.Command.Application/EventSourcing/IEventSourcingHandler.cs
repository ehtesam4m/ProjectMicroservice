using System.Threading.Tasks;
using Project.Command.Domain.EventSourcing;

namespace Project.Command.Application.EventSourcing
{
    public interface IEventSourcingHandler
    {
        Task HandleAsync(IEventSourcing aggregate);
    }
}
