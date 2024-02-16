using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.BranchProducts.Command.Update
{
	public class UpdateBranchProductCommandRequest:IRequest
	{
		public Guid BranchId { get; set; }
		public Guid ProductId { get; set; }
		public int Quantity { get; set; }
        public bool? Process { get; set; }
        public bool? IsActive { get; set; }
	}
}
