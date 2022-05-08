using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Project.Command.Domain.EventSourcing;

namespace Project.Command.Infrastructure
{
    public class DataBaseContext : DbContext
    {
        public DbSet<EventStore> EventStore { get; set; }
        public DataBaseContext()
        {
        }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
