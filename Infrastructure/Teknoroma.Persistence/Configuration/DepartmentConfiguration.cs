using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Persistence.Configuration
{
    public class DepartmentConfiguration : BaseConfiguration<Department>
    {
        public override void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(x => x.DepartmentName).HasMaxLength(128).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(255);

            base.Configure(builder);
        }
    }
}
