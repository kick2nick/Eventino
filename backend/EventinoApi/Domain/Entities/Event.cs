using Domain.Enums;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Event : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public Guid HostId { get; set; }
        public virtual User Host { get; set; }
        public virtual ICollection<User> Attendees { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Interest> Interests { get; set; }
        public EventType Type { get; set; }
        public EventStatus Status { get; set; }
        public int MaxMembers { get; set; }
        public int MinUserAge { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime StartDate { get; set; }
        public int ViewsCount { get; set; }
    }
}
