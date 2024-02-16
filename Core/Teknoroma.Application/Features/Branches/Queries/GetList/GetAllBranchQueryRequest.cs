using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Branches.Queries.GetAll
{
	public class GetAllBranchQueryRequest:IRequest<List<GetAllBranchQueryResponse>>
	{
	}
}
