namespace Teknoroma.Application.Features.OrderDetails.Queries.GetList
{
	public class GetAllOrderDetailQueryResponse
	{
		public Guid OrderId { get; set; }
		public Guid ProductId { get; set; }
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
	}
}
