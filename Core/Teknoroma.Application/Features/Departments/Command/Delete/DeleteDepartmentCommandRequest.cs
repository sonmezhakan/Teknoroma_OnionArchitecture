using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Departments.Command.Delete
{
	public class DeleteDepartmentCommandRequest:IRequest<Unit>
	{
		public Guid ID { get; set; }
	}
}
