using MediatR;

namespace Teknoroma.Application.Features.StockInputs.Command.Create
{
    public class CreateStockInputCommandRequest:IRequest<Unit>
    {
        public Guid BranchID { get; set; }
        public Guid ProductID { get; set; }
        public Guid? SupplierID { get; set; }
        public Guid AppUserID { get; set; }
        public string? InoviceNumber { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public DateTime StockEntryDate { get; set; }
    }
}
