using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Departments.Queries.GetList
{
	public class GetAllDepartmentCommandRequest:IRequest<List<GetAllDepartmentCommandResponse>>
	{
	}
}
