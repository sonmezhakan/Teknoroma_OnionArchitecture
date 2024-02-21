using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Persistence.Configuration
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasOne(x => x.AppUserProfile).WithOne(x => x.AppUser).HasForeignKey<AppUserProfile>(x => x.ID);
			builder.HasOne(x => x.Employee).WithOne(x => x.AppUser).HasForeignKey<Employee>(x => x.ID);

			builder.Navigation(x => x.AppUserProfile).UsePropertyAccessMode(PropertyAccessMode.Property);

        }
    }
}
