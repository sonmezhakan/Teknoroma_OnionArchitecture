namespace Teknoroma.Application.Features.OrderDetails.Queries.GetByOrderAndProductId
{
	public class GetByOrderAndProductIdOrderDetailQueryResponse
	{
        public Guid OrderId { get; set; }
		public Guid ProductId { get; set; }
		public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
