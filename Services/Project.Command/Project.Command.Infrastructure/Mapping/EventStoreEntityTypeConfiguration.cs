using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Command.Domain.EventSourcing;

namespace Project.Command.Infrastructure.Mapping
{
    internal class EventStoreEntityTypeConfiguration : IEntityTypeConfiguration<EventStore>
    {
        public void Configure(EntityTypeBuilder<EventStore> builder)
        {
            builder.ToTable("EventStore")
                .HasKey(o => o.Id);
            builder.Property(e => e.Version).IsRequired();
            builder.Property(e => e.OccurredOn).IsRequired();
            builder.Property(e => e.AggregateId).IsRequired();
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.PayLoad).IsRequired()
                .HasColumnType("text");

            builder.Property(e => e.TypeName).IsRequired()
                .HasMaxLength(250);
        }
    }
}
