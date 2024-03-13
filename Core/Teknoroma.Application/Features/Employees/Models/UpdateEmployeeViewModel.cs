using System.ComponentModel.DataAnnotations;
using Teknoroma.Application.Features.Employees.Contants;

namespace Teknoroma.Application.Features.Employees.Models
{
	public class UpdateEmployeeViewModel
	{
		[Display(Name = EmployeeColumnNames.ID)]
        [Required(ErrorMessage = EmployeesMessages.IDNotNull)]
        public Guid ID { get; set; }

		[Display(Name = EmployeeColumnNames.BranchID)]
        [Required(ErrorMessage = EmployeesMessages.BranchIDNotNull)]
        public Guid BranchID { get; set; }

		[Display(Name = EmployeeColumnNames.DepartmentID)]
        [Required(ErrorMessage = EmployeesMessages.DepartmentIDNotNull)]
        public Guid DepartmentID { get; set; }

		[Display(Name = EmployeeColumnNames.Salary)]
		public decimal? Salary { get; set; }

        public bool IsActive { get; set; }
    }
}
