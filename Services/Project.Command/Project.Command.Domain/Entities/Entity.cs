using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Project.Command.Domain.Entities
{
    public abstract class Entity<T> : IEqualityComparer<Entity<T>>
    {
        public T Id { get; set; }

        protected Entity()
        {
        }

        public override bool Equals(object obj)
        {
            return Equals(this, obj as Entity<T>);
        }
        public bool Equals([AllowNull] Entity<T> x, [AllowNull] Entity<T> y)
        {
            return (x == null && y == null) || (x != null && y != null && EqualityComparer<T>.Default.Equals(x.Id, y.Id));
        }

        public override int GetHashCode()
        {
            return GetHashCode(this);
        }
        public int GetHashCode([DisallowNull] Entity<T> obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
