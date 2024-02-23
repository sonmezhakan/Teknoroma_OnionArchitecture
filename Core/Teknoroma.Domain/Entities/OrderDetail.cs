using Teknoroma.Domain.Abstracts;
using Teknoroma.Domain.Enums;

namespace Teknoroma.Domain.Entities
{
    public class OrderDetail : BaseEntity
    {
		public Guid ProductId { get; set; }
		public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
		

		public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}