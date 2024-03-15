using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Persistence.Configuration
{
	public class ExpenseConfiguration:BaseConfiguration<Expense>
	{
		public override void Configure(EntityTypeBuilder<Expense> builder)
		{
			builder.Property(x => x.Title).HasMaxLength(128).IsRequired();
			builder.Property(x=>x.Description).HasMaxLength(500);
			builder.Property(x => x.Price).HasColumnType("money").IsRequired();

			builder.HasOne(x=>x.Employee).WithMany(x=>x.Expenses).HasForeignKey(x=>x.EmployeeId);

			base.Configure(builder);
		}
	}
}
