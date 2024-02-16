using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Persistence.Configuration
{
    public class CategoryConfiguration : BaseConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.CategoryName).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(255);

            base.Configure(builder);
        }
    }
}
