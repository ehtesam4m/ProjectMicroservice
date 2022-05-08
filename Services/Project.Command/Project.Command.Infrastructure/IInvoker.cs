using Project.Command.Domain.Aggerates;
using System;

namespace Project.Command.Infrastructure
{
    public interface IInvoker<out T> where T : AggregateRoot<Guid>
    {
        T CreateInstanceOfAggregateRoot<T>();
    }
}