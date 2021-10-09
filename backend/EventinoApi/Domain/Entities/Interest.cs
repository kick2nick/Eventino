namespace Domain.Entities
{
    public class Interest : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Id}:{Name}";
        }
    }
}
