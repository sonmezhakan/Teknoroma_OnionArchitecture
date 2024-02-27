using MediatR;

namespace Teknoroma.Application.Features.Stocks.Queries.GetStockTrackingReportList
{
	public class GetStockTrackingReportListQueryRequest:IRequest<List<GetStockTrackingReportListQueryResponse>>
	{
        public Guid BranchId { get; set; }
    }
}
