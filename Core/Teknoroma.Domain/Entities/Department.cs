using Teknoroma.Domain.Abstracts;

namespace Teknoroma.Domain.Entities
{
	public class Department : BaseEntity
    {
        public string DepartmentName { get; set; }
        public string? Description { get; set; }

        public virtual List<Employee> Employees { get; set; }
    }
}
