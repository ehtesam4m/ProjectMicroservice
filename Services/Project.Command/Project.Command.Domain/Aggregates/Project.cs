using System;
using System.Collections.Generic;
using Project.Command.SharedKernel.Events;
using Project.Command.Domain.Entities;

namespace Project.Command.Domain.Aggerates
{
    public class Project : AggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string ClientName { get; set; }
        public string Status { get; set; }
        public IList<ProjectTask> ProjectTasks { get; set; }

        protected Project()
        {
            ProjectTasks = new List<ProjectTask>();
        }
        public Project(Guid id, string name, string clientName)
        {
            AddDomainEvent(new ProjectCreatedEvent(id, name, clientName));
        }

        public void Apply(ProjectCreatedEvent e)
        {
            Id = e.AggregateId;
            Name = e.Name;
            ClientName = e.ClientName;
        }
    }
}
