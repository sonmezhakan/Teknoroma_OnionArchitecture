using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Pipelines.Transaction;

namespace Teknoroma.Application.Features.Brands.Command.Create
{
	public class CreateBrandCommandRequest:IRequest<Unit>, ITransactionalRequest
	{
		public string BrandName { get; set; }
		public string? Description { get; set; }
		public string? PhoneNumber { get; set; }
	}
}
