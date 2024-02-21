namespace Teknoroma.Application.Features.Employees.Models
{
	public class CreateEmployeeViewModel
	{
		public Guid ID { get; set; }
		public Guid BranchID { get; set; }
		public Guid DepartmentID { get; set; }
	}
}
