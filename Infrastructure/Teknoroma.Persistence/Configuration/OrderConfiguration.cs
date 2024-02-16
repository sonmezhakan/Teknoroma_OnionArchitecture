using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Persistence.Configuration
{
    public class OrderConfiguration : BaseConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(x => x.Customer).WithMany(x => x.Orders).HasForeignKey(x => x.CustomerId);
            builder.HasOne(x => x.Employee).WithMany(x => x.Orders).HasForeignKey(x => x.EmployeId);

            base.Configure(builder);
        }
    }
}
