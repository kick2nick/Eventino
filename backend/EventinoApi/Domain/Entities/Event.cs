using System;

namespace Domain.Entities
{
    public class Event : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public User Host { get; set; }
    }
}
