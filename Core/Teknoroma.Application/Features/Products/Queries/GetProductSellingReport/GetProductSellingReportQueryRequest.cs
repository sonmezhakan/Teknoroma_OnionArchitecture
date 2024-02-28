using MediatR;

namespace Teknoroma.Application.Features.Products.Queries.GetProductSellingReport
{
	public class GetProductSellingReportQueryRequest:IRequest<List<GetProductSellingReportQueryResponse>>
	{
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
	}
}
