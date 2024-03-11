using MediatR;
using Teknoroma.Application.Pipelines.Transaction;

namespace Teknoroma.Application.Features.Suppliers.Command.Update
{
	public class UpdateSupplierCommandRequest:IRequest<Unit>, ITransactionalRequest
	{
        public Guid ID { get; set; }
        public string CompanyName { get; set; }
		public string? ContactName { get; set; }
		public string? ContactTitle { get; set; }
		public string? Email { get; set; }
		public string? PhoneNumber { get; set; }
		public string? Address { get; set; }
		public string? WebSite { get; set; }
	}
}
