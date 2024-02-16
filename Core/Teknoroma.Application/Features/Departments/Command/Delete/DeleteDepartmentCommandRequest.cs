using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Departments.Command.Delete
{
	public class DeleteDepartmentCommandRequest:IRequest<string>
	{
		public Guid ID { get; set; }
	}
}
