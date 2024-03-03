using System.ComponentModel.DataAnnotations;
using Teknoroma.Application.Features.AppUserRoles.Models;
using Teknoroma.Application.Features.Employees.Contants;

namespace Teknoroma.Application.Features.Employees.Models
{
	public class CreateEmployeeViewModel
	{
		[Display(Name = EmployeeColumnNames.ID)]
		public Guid ID { get; set; }

		[Display(Name = EmployeeColumnNames.BranchID)]
		public Guid BranchID { get; set; }

		[Display(Name = EmployeeColumnNames.DepartmentID)]
		public Guid DepartmentID { get; set; }

		[Display(Name = EmployeeColumnNames.Salary)]
		public decimal? Salary { get; set; }
	}
}
