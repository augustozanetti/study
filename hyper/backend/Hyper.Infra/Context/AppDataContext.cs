using Hyper.Domain.Entities;
using Hyper.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Hyper.Infra.Context
{
    public class AppDataContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=hyper;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PersonMap());
            builder.ApplyConfiguration(new AddressMap());
        }
    }
}