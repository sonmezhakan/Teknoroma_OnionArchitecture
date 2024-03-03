namespace Teknoroma.Application.Features.Suppliers.Models
{
	public class SupplierSupplyReportViewModel
	{
		public Guid SupplierId { get; set; }
		public string CompanyName { get; set; }
		public int TotalSupply { get; set; }
	}
}
