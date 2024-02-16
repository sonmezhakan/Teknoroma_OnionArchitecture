using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Persistence.Configuration
{
    public class BrandConfiguration : BaseConfiguration<Brand>
    {
        public override void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(x => x.BrandName).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(255);
            builder.Property(x => x.PhoneNumber).HasColumnType("char(11)");

            base.Configure(builder);
        }
    }
}
