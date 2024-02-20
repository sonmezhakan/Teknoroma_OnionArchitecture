using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Persistence.Configuration
{
    public class StockConfiguration : BaseConfiguration<Stock>
    {
        public override void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.Ignore(x =>x.ID);

            builder.HasKey(x => new { x.BranchId, x.ProductId });

            builder.Property(x => x.UnitsInStock).IsRequired();

            builder.HasOne(x => x.Branch).WithMany(x => x.stocks).HasForeignKey(x => x.BranchId);
            builder.HasOne(x => x.Product).WithMany(x => x.stocks).HasForeignKey(x => x.ProductId);

            base.Configure(builder);
        }
    }
}
