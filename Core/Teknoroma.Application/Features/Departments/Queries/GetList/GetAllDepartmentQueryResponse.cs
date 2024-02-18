using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Departments.Queries.GetList
{
	public class GetAllDepartmentQueryResponse
	{
		public Guid ID { get; set; }
		public string DepartmentName { get; set; }
        public int EmployeeCount { get; set; }
        public string Description { get; set; }
	}
}
