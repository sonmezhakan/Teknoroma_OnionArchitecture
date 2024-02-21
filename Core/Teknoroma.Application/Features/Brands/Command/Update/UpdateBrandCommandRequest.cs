using MediatR;
using Teknoroma.Application.Pipelines.Transaction;

namespace Teknoroma.Application.Features.Brands.Command.Update
{
	public class UpdateBrandCommandRequest:IRequest<Unit>, ITransactionalRequest
	{
		public Guid ID { get; set; }
		public string BrandName { get; set; }
		public string? Description { get; set; }
		public string? PhoneNumber { get; set; }
	}
}
