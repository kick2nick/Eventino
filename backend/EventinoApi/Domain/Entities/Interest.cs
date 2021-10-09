using System.Collections.Generic;

namespace Domain.Entities
{
    public class Interest : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public override string ToString()
        {
            return $"{Id}:{Name}";
        }
    }
}
