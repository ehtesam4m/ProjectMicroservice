using System;
using System.Collections.Generic;
using Project.Command.SharedKernel.Events;
using Project.Domain.Entities;

namespace Project.Command.Domain.Aggerates
{
    public class Project : AggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string ClientName { get; set; }
        public string Status { get; set; }
        public ICollection<ProjectTask> ProjectTasks { get; set; }

        public void UpdateSchedule(string name, string clientName, int originalVersion)
        {
            AddDomainEvent(new ProjectCreatedEvent(Id, name, clientName), originalVersion);
        }

        public void Apply(ProjectCreatedEvent e)
        {
            Name = e.Name;
            ClientName = e.ClientName;
        }
    }
}
