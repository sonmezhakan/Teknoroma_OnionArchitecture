using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Persistence.Configuration
{
    public class BranchConfiguration : BaseConfiguration<Branch>
    {
        public override void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.Property(x => x.BranchName).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(255);
            builder.Property(x => x.PhoneNumber).HasColumnType("char(11)");
            builder.Property(x => x.Description).HasMaxLength(255);

            base.Configure(builder);
        }
    }
}
