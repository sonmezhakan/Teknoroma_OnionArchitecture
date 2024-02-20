
namespace Teknoroma.Application.Features.StockInputs.Models
{
    public class StockInputListViewModel
    {
        public Guid ID { get; set; }
        public string BranchName { get; set; }
        public string ProductName { get; set; }
        public string CompanyName { get; set; }
        public string AppUserName { get; set; }
        public string InoviceNumber { get; set; }
        public int Quantity { get; set; }
        public DateTime StockEntryDate { get; set; }
        public string Description { get; set; }
    }
}
