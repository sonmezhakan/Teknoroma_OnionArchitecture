using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Departments.Queries.GetById
{
	public class GetByIdDepartmentQueryResponse
	{
		public Guid ID { get; set; }
		public string DepartmentName { get; set; }
		public string Description { get; set; }
	}
}
