using Microsoft.EntityFrameworkCore;
using Project.Command.Application.Common.Interfaces;
using Project.Command.Domain.Aggerates;
using Project.Command.Domain.EventSourcing;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Command.Infrastructure
{
    public class EventStoreRepository<T> : Repository<EventStore, Guid>, IEventStoreRepository where T : AggregateRoot<Guid>
    {
        private readonly IInvoker<T> _invoker;
        private readonly IDomainEventRebuilder _eventStoreToEVent;
        public EventStoreRepository(DataBaseContext context, IInvoker<T> invoker, IDomainEventRebuilder eventStoreToEVent) : base(context)
        {
            _invoker = invoker;
            _eventStoreToEVent = eventStoreToEVent;
        }

        public async Task AppendAsync(EventStore @event)
        {
            await repoDbSet.AddAsync(@event);
        }

        public async Task<T> GetByIdAsync<T>(Guid aggregateId) where T : AggregateRoot<Guid>
        {
            var eventStoreItems = repoDbSet.AsNoTracking().Where(e => e.AggregateId == aggregateId).AsQueryable();
            var aggregate = _invoker.CreateInstanceOfAggregateRoot<T>();
            
            if (!eventStoreItems.Any())
            {
                return await Task.FromResult(aggregate);
            }

            var events = _eventStoreToEVent.RebuildDomainEvents(eventStoreItems);
            aggregate.LoadFromHistory(events);

            return await Task.FromResult(aggregate);
        }
    }
}
