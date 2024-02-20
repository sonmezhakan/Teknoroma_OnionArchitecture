
using System.ComponentModel.DataAnnotations;
using Teknoroma.Application.Features.Categories.Constants;

namespace Teknoroma.Application.Features.Categories.Models
{
    public class CreateCategoryViewModel
    {
		[Display(Name = CategoryColumnNames.CategoryName)]
		public string CategoryName { get; set; }

		[Display(Name = CategoryColumnNames.Description)]
		public string? Description { get; set; }
	}
}
