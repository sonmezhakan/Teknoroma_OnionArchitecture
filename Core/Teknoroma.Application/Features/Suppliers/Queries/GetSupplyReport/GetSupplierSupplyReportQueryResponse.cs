namespace Teknoroma.Application.Features.Suppliers.Queries.GetSupplyReport
{
	public class GetSupplierSupplyReportQueryResponse
	{
        public Guid SupplierId { get; set; }
        public string CompanyName { get; set; }
        public int TotalSupply { get; set; }
    }
}
