using MediatR;

namespace Teknoroma.Application.Features.StockInputs.Command.Delete
{
    public class DeleteStockInputCommandRequest:IRequest<Unit>
    {
        public Guid ID { get; set; }
    }
}
