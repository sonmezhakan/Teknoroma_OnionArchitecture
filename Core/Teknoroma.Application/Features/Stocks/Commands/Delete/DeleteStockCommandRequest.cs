using MediatR;

namespace Teknoroma.Application.Features.Stocks.Command.Delete
{
	public class DeleteStockCommandRequest : IRequest<Unit>
    {
        public Guid BranchId { get; set; }
        public Guid ProductId { get; set; }
    }
}
