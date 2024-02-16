using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Persistence.Configuration
{
    public class OrderDetailConfiguration : BaseConfiguration<OrderDetail>
    {
        public override void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.Property(x => x.UnitPrice).HasColumnType("money").IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.Discount).HasColumnType("real");

            builder.HasOne(x => x.Order).WithMany(x => x.OrderDetails).HasForeignKey(x => x.ID);
            builder.HasOne(x => x.Product).WithMany(x => x.OrderDetails).HasForeignKey(x => x.ProductId);

            base.Configure(builder);
        }
    }
}
