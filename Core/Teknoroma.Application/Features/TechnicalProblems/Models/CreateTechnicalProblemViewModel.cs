using System.ComponentModel.DataAnnotations;
using Teknoroma.Application.Features.TechnicalProblems.Contants;

namespace Teknoroma.Application.Features.TechnicalProblems.Models
{
	public class CreateTechnicalProblemViewModel
    {
        [Display(Name = TechnicalProblemColumnNames.ReportedProblem)]
        [Required(ErrorMessage = TechnicalProblemsMessages.ReportedProblemNotNull)]
        public string ReportedProblem { get; set; }
    }
}
