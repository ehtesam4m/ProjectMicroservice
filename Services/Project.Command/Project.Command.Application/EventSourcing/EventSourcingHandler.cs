using Project.Command.Application.Common.Interfaces;
using System.Threading.Tasks;
using Project.Command.SharedKernel.Serialyser;
using Project.Command.Domain.EventSourcing;
using Project.Command.SharedKernel.Events;
using Project.Command.Application.Common.Exceptions;

namespace Project.Command.Application.EventSourcing
{
    public class EventSourcingHandler : IEventSourcingHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IEventSerializer _eventSerializer;

        public EventSourcingHandler(IUnitOfWork unitOfWork, IEventStoreRepository eventStoreRepository,
            IEventSerializer eventSerializer)
        {
            _unitOfWork = unitOfWork;
            _eventStoreRepository = eventStoreRepository;
            _eventSerializer = eventSerializer;
        }

        public async Task HandleAsync(IEventSourcing aggregate)


        {
            int aggregateVersion = aggregate.Version;
            foreach (var evt in aggregate.GetUncommittedEvents())
            {

                var @event = (Event)evt;

                if (@event == null)
                {
                    throw new EventNullException(nameof(@event));
                }

                var serializedBody = _eventSerializer.Serialize(@event);

                var eventStore = new EventStore(@event.AggregateId, aggregateVersion,
                    $"{aggregateVersion}@{@event.AggregateId}",
                    @event.GetType().Name,
                    @event.OcurrendOn,
                    serializedBody);
                await _eventStoreRepository.AppendAsync(eventStore);
            }
            _unitOfWork.Commit();
        }
    }
}
