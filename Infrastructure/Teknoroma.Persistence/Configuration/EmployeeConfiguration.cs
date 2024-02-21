using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Persistence.Configuration
{
	public class EmployeeConfiguration : BaseConfiguration<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {

            builder.HasOne(x => x.Branch).WithMany(x => x.Employees).HasForeignKey(x => x.BranchID);
            builder.HasOne(x => x.Department).WithMany(x => x.Employees).HasForeignKey(x => x.DepartmentID);

            base.Configure(builder);
        }
    }
}
