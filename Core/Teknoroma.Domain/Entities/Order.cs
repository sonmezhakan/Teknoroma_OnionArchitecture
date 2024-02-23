using Teknoroma.Domain.Abstracts;
using Teknoroma.Domain.Enums;

namespace Teknoroma.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Order()
        {
			OrderStatu = OrderStatu.Hazırlanıyor;
		}
        public Guid BranchId { get; set; }
		public Guid EmployeeId { get; set; }
		public Guid CustomerId { get; set; }
		public DateTime OrderDate { get; set; }
		public OrderStatu OrderStatu { get; set; }

		public virtual Branch Branch { get; set; }
		public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
		public virtual  List<OrderDetail> OrderDetails { get; set; }
    }
}