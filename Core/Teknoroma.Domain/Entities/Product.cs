using Teknoroma.Domain.Abstracts;

namespace Teknoroma.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int CriticalStock { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        public Guid? BrandId { get; set; }
        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Brand? Brand { get; set; }

        public virtual List<Stock> stocks { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
        public virtual List<StockInput> StockInputs { get; set; }
    }
}