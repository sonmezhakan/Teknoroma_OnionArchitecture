using System.ComponentModel.DataAnnotations;
using Teknoroma.Application.Features.Departments.Contants;

namespace Teknoroma.Application.Features.Departments.Models
{
    public class DepartmentViewModel
    {
        [Display(Name = DepartmentColumnNames.ID)]
        [Required(ErrorMessage = DepartmentsMessages.IDNotNull)]
        public Guid ID { get; set; }

		[Display(Name = DepartmentColumnNames.DepartmentName)]
        [Required(ErrorMessage = DepartmentsMessages.DepartmentNotNull)]
        public string DepartmentName { get; set; }

		[Display(Name = DepartmentColumnNames.Description)]
		public string? Description { get; set; }
    }
}
