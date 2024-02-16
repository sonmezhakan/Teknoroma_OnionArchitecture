using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Branches.Queries.GetById
{
	public class GetByIdBranchQueryRequest:IRequest<GetByIdBranchQueryResponse>
	{
        public Guid ID { get; set; }
    }
}
