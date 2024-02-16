using Teknoroma.Domain.Abstracts;

namespace Teknoroma.Domain.Entities
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }

        public Guid CustomerId { get; set; }
        public Guid EmployeId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }

		public virtual  List<OrderDetail> OrderDetails { get; set; }
    }
}