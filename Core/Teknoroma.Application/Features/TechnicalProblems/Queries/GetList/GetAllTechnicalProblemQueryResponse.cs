using Teknoroma.Domain.Enums;

namespace Teknoroma.Application.Features.TechnicalProblems.Queries.GetList
{
    public class GetAllTechnicalProblemQueryResponse
    {
        public Guid ID { get; set; }
        public string ReportedProblem { get; set; }
        public string ProblemSolution { get; set; }
        public DateTime NotificationDate { get; set; }
        public string BranchName { get; set; }
        public string AppUserName { get; set; }
        public TechnicalProblemStatu TechnicalProblemStatu { get; set; }
    }
}
