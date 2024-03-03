using MediatR;

namespace Teknoroma.Application.Features.Suppliers.Queries.GetSupplyReport
{
	public class GetSupplierSupplyReportQueryRequest:IRequest<List<GetSupplierSupplyReportQueryResponse>>
	{
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
