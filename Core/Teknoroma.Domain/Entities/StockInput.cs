using Teknoroma.Domain.Abstracts;

namespace Teknoroma.Domain.Entities
{
    public class StockInput:BaseEntity
    {
        public Guid BranchID { get; set; }
        public Guid ProductID { get; set; }
        public Guid? SupplierID { get; set; }
        public Guid AppUserID { get; set; }
        public string? InoviceNumber { get; set; }
        public int Quantity { get; set; }
        public DateTime StockEntryDate { get; set; }
        public string? Description { get; set; }
        

        public virtual Branch Branch { get; set; }
        public virtual Product Product { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
