using Hyper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hyper.Infra.Mappings
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Street)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder
                .Property(x => x.Number)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");
            
            builder
                .Property(x => x.City)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnType("varchar(80)");

            builder.Property(x => x.State)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnType("varchar(80)");
        }
    }
}