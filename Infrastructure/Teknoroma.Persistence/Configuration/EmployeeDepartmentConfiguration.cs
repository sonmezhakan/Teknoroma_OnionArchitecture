using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Persistence.Configuration
{
    public class EmployeeDepartmentConfiguration : BaseConfiguration<EmployeeDepartment>
    {
        public override void Configure(EntityTypeBuilder<EmployeeDepartment> builder)
        {
            builder.Ignore(x => x.ID);

            builder.HasKey(x => new { x.EmployeeId, x.DepartmentId });

            builder.HasOne(x => x.Employee).WithMany(x => x.EmployeeDepartments).HasForeignKey(x => x.EmployeeId);
            builder.HasOne(x => x.Department).WithMany(x => x.EmployeeDepartments).HasForeignKey(x => x.DepartmentId);

            base.Configure(builder);
        }
    }
}
