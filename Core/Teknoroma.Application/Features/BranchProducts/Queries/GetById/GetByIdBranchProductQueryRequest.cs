using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Features.BranchProducts.Queries.GetByBranchId;

namespace Teknoroma.Application.Features.BranchProducts.Queries.GetById
{
	public class GetByIdBranchProductQueryRequest:IRequest<GetByIdBranchProductQueryResponse>
	{
        public Guid BranchID { get; set; }
		public Guid ProductID { get; set; }
	}
}
