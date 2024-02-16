using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Persistence.Configuration
{
    public class EmployeeConfiguration : BaseConfiguration<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {

            builder.Property(x => x.FirstName).HasMaxLength(64).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(64).IsRequired();
            builder.Property(x => x.PhoneNumber).HasColumnType("char(11)").IsRequired();
            builder.Property(x => x.Address).HasMaxLength(255).IsRequired();
            builder.Property(x => x.ImagePath).HasMaxLength(255);
            builder.Property(x => x.Description).HasMaxLength(255);

            builder.HasOne(x => x.AppUser).WithMany(x => x.Employees).HasForeignKey(x => x.ID);

            base.Configure(builder);
        }
    }
}
