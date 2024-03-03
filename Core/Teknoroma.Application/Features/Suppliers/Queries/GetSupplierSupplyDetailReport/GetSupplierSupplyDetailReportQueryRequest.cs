using MediatR;

namespace Teknoroma.Application.Features.Suppliers.Queries.GetSupplierSupplyDetailReport
{
	public class GetSupplierSupplyDetailReportQueryRequest:IRequest<List<GetSupplierSupplyDetailReportQueryResponse>>
	{
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
	}
}
