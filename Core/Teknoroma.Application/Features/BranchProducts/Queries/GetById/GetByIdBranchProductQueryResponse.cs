using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.BranchProducts.Queries.GetById
{
	public class GetByIdBranchProductQueryResponse
	{
		public Guid BranchId { get; set; }
		public Guid ProductId { get; set; }
		public int UnitsInStock { get; set; }
	}
}
