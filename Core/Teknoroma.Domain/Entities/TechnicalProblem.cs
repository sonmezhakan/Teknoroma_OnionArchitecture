using Teknoroma.Domain.Abstracts;
using Teknoroma.Domain.Enums;

namespace Teknoroma.Domain.Entities
{
    public class TechnicalProblem:BaseEntity
    {
        public string ReportedProblem { get; set; }
        public string? ProblemSolution { get; set; }
        public DateTime NotificationDate { get; set; }
        public Guid BranchId { get; set; }
        public Guid EmployeeId { get; set; }
        public TechnicalProblemStatu TechnicalProblemStatu { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
