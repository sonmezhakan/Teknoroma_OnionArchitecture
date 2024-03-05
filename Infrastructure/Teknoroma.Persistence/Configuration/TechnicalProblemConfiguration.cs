using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Persistence.Configuration
{
    public class TechnicalProblemConfiguration:BaseConfiguration<TechnicalProblem>
    {
        public override void Configure(EntityTypeBuilder<TechnicalProblem> builder)
        {
            builder.Property(x => x.ReportedProblem).HasMaxLength(500).IsRequired();
            builder.Property(x=>x.ProblemSolution).HasMaxLength(500);
            builder.Property(x => x.TechnicalProblemStatu).HasColumnType("smallint").IsRequired();

            builder.HasOne(x => x.Branch).WithMany(x => x.TechnicalProblems).HasForeignKey(x => x.BranchId);
            builder.HasOne(x=>x.Employee).WithMany(x=>x.TechnicalProblems).HasForeignKey(x=>x.EmployeeId).OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);
        }
    }
}
