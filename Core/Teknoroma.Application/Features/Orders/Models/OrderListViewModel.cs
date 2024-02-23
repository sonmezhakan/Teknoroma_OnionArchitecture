using Teknoroma.Domain.Enums;

namespace Teknoroma.Application.Features.Orders.Models
{
	public class OrderListViewModel
	{
		public Guid ID { get; set; }
		public string UserName { get; set; }
		public string BranchName { get; set; }
		public string CustomerName { get; set; }
		public string CustomerPhoneNumber { get; set; }
		public int TotalProductQuantity { get; set; }
		public decimal TotalPrice { get; set; }
		public OrderStatu OrderStatu { get; set; }
		public DateTime OrderDate { get; set; }
	}
}
