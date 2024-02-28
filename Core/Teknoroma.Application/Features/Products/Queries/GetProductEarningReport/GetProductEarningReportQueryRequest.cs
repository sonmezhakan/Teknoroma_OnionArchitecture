using MediatR;

namespace Teknoroma.Application.Features.Products.Queries.GetProductEarningReport
{
	public class GetProductEarningReportQueryRequest:IRequest<List<GetProductEarningReportQueryResponse>>
	{
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
