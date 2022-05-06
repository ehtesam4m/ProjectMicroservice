using System;
using System.Collections.Generic;
using Project.Command.Domain.Entities;

namespace Project.Domain.Entities
{
    public class ProjectTask : Entity<Guid>
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
    }
}
