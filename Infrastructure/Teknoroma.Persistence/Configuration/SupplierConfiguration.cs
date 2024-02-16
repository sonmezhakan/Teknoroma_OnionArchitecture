using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Persistence.Configuration
{
    public class SupplierConfiguration : BaseConfiguration<Supplier>
    {
        public override void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.Property(x => x.CompanyName).HasMaxLength(255).IsRequired();
            builder.Property(x => x.ContactName).HasMaxLength(128);
            builder.Property(x => x.ContactTitle).HasMaxLength(128);
            builder.Property(x => x.Email).HasMaxLength(128);
            builder.Property(x => x.PhoneNumber).HasColumnType("char(11)");
            builder.Property(x => x.Address).HasMaxLength(255);
            builder.Property(x => x.WebSite).HasMaxLength(255);

            base.Configure(builder);
        }
    }
}
