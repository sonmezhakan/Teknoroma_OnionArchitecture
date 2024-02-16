using Teknoroma.Domain.Abstracts;

namespace Teknoroma.Domain.Entities
{
    public class OrderDetail : BaseEntity
    {
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal? Discount { get; set; }

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        public virtual Order Order { get; set; }
    }
}