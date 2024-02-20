
namespace Teknoroma.Application.Features.StockInputs.Queries.GetById
{
    public class GetByIdStockInputQueryResponse
    {
        public Guid ID { get; set; }
        public Guid BranchID { get; set; }
        public Guid ProductID { get; set; }
        public Guid SupplierID { get; set; }
        public Guid AppUserID { get; set; }
        public string InoviceNumber { get; set; }
        public int Quantity { get; set; }
        public DateTime StockEntryDate { get; set; }
        public string Description { get; set; }
    }
}
