using MediatR;
using Teknoroma.Application.Pipelines.Transaction;
using Teknoroma.Domain.Enums;

namespace Teknoroma.Application.Features.Customers.Command.Update
{
	public class UpdateCustomerCommandRequest:IRequest<Unit>, ITransactionalRequest
	{
		public Guid ID { get; set; }
		public string FullName { get; set; }
		public string? ContactName { get; set; }
		public string? ContactTitle { get; set; }
		public string PhoneNumber { get; set; }
		public string? Address { get; set; }
		public InvoiceEnum Invoice { get; set; }
	}
}
