using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Features.BranchProducts.Queries.GetByBranchId;

namespace Teknoroma.Application.Features.BranchProducts.Queries.GetByBranchId
{
	public class GetByIdBranchProductQueryRequest:IRequest<GetByBranchIdBranchProductQueryResponse>
	{
        public Guid BranchID { get; set; }
    }
}
