using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Persistence.Configuration
{
    public class BranchProductConfiguration : BaseConfiguration<BranchProduct>
    {
        public override void Configure(EntityTypeBuilder<BranchProduct> builder)
        {
            builder.Ignore(x =>x.ID);

            builder.HasKey(x => new { x.BranchId, x.ProductId });

            builder.Property(x => x.UnitsInStock).IsRequired();

            builder.HasOne(x => x.Branch).WithMany(x => x.BranchProducts).HasForeignKey(x => x.BranchId);
            builder.HasOne(x => x.Product).WithMany(x => x.BranchProducts).HasForeignKey(x => x.ProductId);

            base.Configure(builder);
        }
    }
}
