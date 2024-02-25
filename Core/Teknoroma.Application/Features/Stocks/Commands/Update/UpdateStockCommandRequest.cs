using MediatR;


namespace Teknoroma.Application.Features.Stocks.Command.Update
{
    public class UpdateStockCommandRequest : IRequest<Unit>
    {
        public Guid BranchId { get; set; }
        public Guid ProductId { get; set; }
        public int UnitsInStock { get; set; }
    }
}
