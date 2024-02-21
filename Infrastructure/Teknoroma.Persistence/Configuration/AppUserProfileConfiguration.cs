using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Persistence.Configuration
{
    public class AppUserProfileConfiguration:BaseConfiguration<AppUserProfile>
    {
        public override void Configure(EntityTypeBuilder<AppUserProfile> builder)
        {
            builder.Property(x=>x.FirstName).HasMaxLength(64).IsRequired();
            builder.Property(x=>x.LastName).HasMaxLength(64).IsRequired();
            builder.Property(x => x.NationalityNumber).HasMaxLength(32);
            builder.Property(x => x.Address).HasMaxLength(255);

            base.Configure(builder);
        }
    }
}
