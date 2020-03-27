using Hyper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hyper.Infra.Mappings
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder
                .Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");
            
            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnType("varchar(80)");

            builder
                .HasMany(x => x.Addresses)
                .WithOne(x => x.Person);

        }
    }
}