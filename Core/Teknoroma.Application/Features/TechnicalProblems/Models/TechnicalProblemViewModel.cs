using System.ComponentModel.DataAnnotations;
using Teknoroma.Application.Features.TechnicalProblems.Contants;
using Teknoroma.Domain.Enums;

namespace Teknoroma.Application.Features.TechnicalProblems.Models
{
    public class TechnicalProblemViewModel
    {
        [Display(Name = TechnicalProblemColumnNames.ID)]
        [Required(ErrorMessage = TechnicalProblemsMessages.IDNotNull)]
        public Guid? ID { get; set; }

		[Display(Name = TechnicalProblemColumnNames.ReportedProblem)]
        [Required(ErrorMessage = TechnicalProblemsMessages.ReportedProblemNotNull)]
        public string ReportedProblem { get; set; }

		[Display(Name = TechnicalProblemColumnNames.ProblemSolution)]
		public string? ProblemSolution { get; set; }

		[Display(Name = TechnicalProblemColumnNames.NotificationDate)]
		public DateTime NotificationDate { get; set; }

        [Display(Name = TechnicalProblemColumnNames.BranchId)]
        [Required(ErrorMessage = TechnicalProblemsMessages.BranchIdNotNull)]
        public Guid BranchId { get; set; }

        [Display(Name = TechnicalProblemColumnNames.BranchName)]
		public string? BranchName { get; set; }

        [Display(Name = TechnicalProblemColumnNames.EmployeeId)]
        [Required(ErrorMessage = TechnicalProblemsMessages.EmployeeIdNotNull)]
        public Guid EmployeeId { get; set; }

        [Display(Name = TechnicalProblemColumnNames.AppUserName)]
		public string? AppUserName { get; set; }

		[Display(Name = TechnicalProblemColumnNames.TechnicalProblemStatu)]
		public TechnicalProblemStatu? TechnicalProblemStatu { get; set; }
    }
}
