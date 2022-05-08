using System;
using System.Reflection;
using Project.Command.Domain.Aggerates;

namespace Project.Command.Infrastructure
{
    public class Invoker<T> : IInvoker<T> where T : AggregateRoot<Guid>
    {
        public T CreateInstanceOfAggregateRoot<T>()
        {
            return (T)typeof(T)
                .GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic,
                    null,
                    new Type[0],
                    new ParameterModifier[0])
                ?.Invoke(new object[0]);
        }
    }
}