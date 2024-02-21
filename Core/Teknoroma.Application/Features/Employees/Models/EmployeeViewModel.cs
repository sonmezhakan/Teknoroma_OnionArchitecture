using System.ComponentModel.DataAnnotations;
using Teknoroma.Application.Features.Employees.Contants;

namespace Teknoroma.Application.Features.Employees.Models
{
	public class EmployeeViewModel
	{
		[Display(Name = EmployeeColumnNames.ID)]
		public Guid ID { get; set; }

		[Display(Name = EmployeeColumnNames.BranchID)]
		public Guid BranchID { get; set; }

		[Display(Name = EmployeeColumnNames.DepartmentID)]
		public Guid DepartmentID { get; set; }

		[Display(Name = EmployeeColumnNames.BranchName)]
		public string BranchName { get; set; }

		[Display(Name = EmployeeColumnNames.DepartmentName)]
		public string DepartmentName { get; set; }

		[Display(Name = EmployeeColumnNames.UserName)]
		public string UserName { get; set; }

		[Display(Name = EmployeeColumnNames.Email)]
		public string Email { get; set; }

		[Display(Name = EmployeeColumnNames.FirstName)]
		public string FirstName { get; set; }

		[Display(Name = EmployeeColumnNames.LastName)]
		public string LastName { get; set; }

		[Display(Name = EmployeeColumnNames.NationalityNumber)]
		public string NationalityNumber { get; set; }

		[Display(Name = EmployeeColumnNames.PhoneNumber)]
		public string PhoneNumber { get; set; }

		[Display(Name = EmployeeColumnNames.Address)]
		public string Address { get; set; }
	}
}
