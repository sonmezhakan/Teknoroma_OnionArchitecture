using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Persistence.Configuration
{
    public class StockInputConfiguration:BaseConfiguration<StockInput>
    {
        public override void Configure(EntityTypeBuilder<StockInput> builder)
        {
            builder.Property(x => x.Description).HasMaxLength(255);
            builder.Property(x => x.InoviceNumber).HasMaxLength(64);

            builder.HasOne(x => x.Branch).WithMany(x => x.StockInputs).HasForeignKey(x => x.BranchID);
            builder.HasOne(x => x.Product).WithMany(x => x.StockInputs).HasForeignKey(x => x.ProductID);
            builder.HasOne(x => x.Supplier).WithMany(x => x.StockInputs).HasForeignKey(x => x.SupplierID);
            builder.HasOne(x=>x.AppUser).WithMany(x=>x.StockInputs).HasForeignKey(x=>x.AppUserID);

            base.Configure(builder);
        }
    }
}
