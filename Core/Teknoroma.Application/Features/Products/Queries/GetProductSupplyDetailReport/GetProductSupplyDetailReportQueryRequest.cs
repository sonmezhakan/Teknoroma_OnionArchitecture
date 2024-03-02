using MediatR;

namespace Teknoroma.Application.Features.Products.Queries.GetProductSupplyDetailReport
{
	public class GetProductSupplyDetailReportQueryRequest:IRequest<List<GetProductSupplyDetailReportQueryResponse>>
	{
		public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
