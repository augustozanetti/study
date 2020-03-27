namespace Hyper.Domain.Entities
{
    public class Address: Entity
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}