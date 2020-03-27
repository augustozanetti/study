using Hyper.Domain.Entities;
using Hyper.Domain.Interfaces.Repositories;
using Hyper.Infra.Context;

namespace Hyper.Infra.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(AppDataContext context) : base(context)
        {

        }
    }
}