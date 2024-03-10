namespace Teknoroma.Application.Features.OrderDetails.Queries.GetById
{
	public class GetByIdOrderDetailQueryResponse
	{
		public Guid OrderId { get; set; }
		public Guid ProductId { get; set; }
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
	}
}
