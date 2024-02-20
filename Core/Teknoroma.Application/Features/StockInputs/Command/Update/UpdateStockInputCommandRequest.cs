using MediatR;

namespace Teknoroma.Application.Features.StockInputs.Command.Update
{
    public class UpdateStockInputCommandRequest:IRequest<Unit>
    {
        public Guid ID { get; set; }
        public Guid BranchID { get; set; }
        public Guid ProductID { get; set; }
        public Guid? SupplierID { get; set; }
        public string? InoviceNumber { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
    }
}
