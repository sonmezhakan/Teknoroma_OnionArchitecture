using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Suppliers.Command.Create
{
	public class CreateSupplierCommandRequest : IRequest<Unit>
	{
		public string CompanyName { get; set; }
		public string? ContactName { get; set; }
		public string? ContactTitle { get; set; }
		public string? Email { get; set; }
		public string? PhoneNumber { get; set; }
		public string? Address { get; set; }
		public string? WebSite { get; set; }
	}
}
