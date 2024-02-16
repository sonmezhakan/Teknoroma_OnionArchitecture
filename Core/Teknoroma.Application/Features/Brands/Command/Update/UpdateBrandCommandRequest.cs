using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Brands.Command.Update
{
	public class UpdateBrandCommandRequest:IRequest<string>
	{
		public Guid ID { get; set; }
		public string BrandName { get; set; }
		public string? Description { get; set; }
		public string? PhoneNumber { get; set; }
		public bool? IsActive { get; set; }
	}
}
