using System;

namespace Domain.Entities
{
    public class Friendship : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public User User1 { get; set; }

        public User User2 { get; set; }
    }
}
