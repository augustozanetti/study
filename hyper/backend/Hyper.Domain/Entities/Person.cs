using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Hyper.Domain.Entities
{
    public class Person : Entity
    {
        public Person()
        {

        }
        public Person(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Addresses = new List<Address>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}