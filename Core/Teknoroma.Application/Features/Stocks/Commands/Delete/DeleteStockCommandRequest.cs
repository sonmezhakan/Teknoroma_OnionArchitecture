using MediatR;
using Teknoroma.Application.Pipelines.Transaction;

namespace Teknoroma.Application.Features.Stocks.Command.Delete
{
	public class DeleteStockCommandRequest : IRequest<Unit>, ITransactionalRequest
	{
        public Guid BranchId { get; set; }
        public Guid ProductId { get; set; }
    }
}
