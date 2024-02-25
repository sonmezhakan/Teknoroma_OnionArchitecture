using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Persistence.Configuration
{
    public class CustomerConfiguration : BaseConfiguration<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.FullName).HasMaxLength(64).IsRequired();
            builder.Property(x => x.ContactName).HasMaxLength(64);
            builder.Property(x => x.ContactTitle).HasMaxLength(64);
            builder.Property(x => x.Email).HasMaxLength(128);
            builder.Property(x => x.PhoneNumber).HasColumnType("char(11)").IsRequired();
            builder.Property(x => x.Address).HasMaxLength(255);
            builder.Property(x => x.Invoice).HasColumnType("smallint");

            base.Configure(builder);
        }
    }
}
