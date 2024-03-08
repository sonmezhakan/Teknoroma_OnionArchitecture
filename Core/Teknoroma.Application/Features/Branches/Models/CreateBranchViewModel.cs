using System.ComponentModel.DataAnnotations;
using Teknoroma.Application.Features.Branches.Constants;

namespace Teknoroma.Application.Features.Branches.Models
{
    public class CreateBranchViewModel
    {
		[Display(Name = BranchColumnNames.BranchName)]
		[Required(ErrorMessage = BranchesMessages.BranchNameNotNull)]
		public string BranchName { get; set; }

		[Display(Name = BranchColumnNames.Address)]
		public string? Address { get; set; }

		[Display(Name = BranchColumnNames.PhoneNumber)]
		public string? PhoneNumber { get; set; }

		[Display(Name = BranchColumnNames.Description)]
		public string? Description { get; set; }
	}
}
