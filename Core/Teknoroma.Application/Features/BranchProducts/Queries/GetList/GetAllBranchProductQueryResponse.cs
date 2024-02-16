namespace Teknoroma.Application.Features.BranchProducts.Queries.GetList
{
	public class GetAllBranchProductQueryResponse
	{
		public string BranchName { get; set; }
		public string ProductName { get; set; }
		public decimal UnitPrice { get; set; }
		public int UnitsInStock { get; set; }
		public int CriticalStock { get; set; }
		public bool IsActive { get; set; }
	}
	
}
