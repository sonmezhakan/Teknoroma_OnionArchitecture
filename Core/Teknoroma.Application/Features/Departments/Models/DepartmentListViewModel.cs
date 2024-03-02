namespace Teknoroma.Application.Features.Departments.Models
{
	public class DepartmentListViewModel
    {
        public Guid ID { get; set; }

        public string DepartmentName { get; set; }

        public int EmployeeCount { get; set; }

        public string Description { get; set; }
    }
}
