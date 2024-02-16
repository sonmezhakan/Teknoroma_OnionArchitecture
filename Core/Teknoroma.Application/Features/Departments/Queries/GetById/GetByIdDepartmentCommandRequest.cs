using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Features.Departments.Queries.GetList;

namespace Teknoroma.Application.Features.Departments.Queries.GetById
{
	public class GetByIdDepartmentCommandRequest:IRequest<GetByIdDepartmentCommandResponse>
	{
        public Guid ID { get; set; }
    }
}
