using MediatR;

namespace Teknoroma.Application.Features.Products.Queries.GetProductSalesDetailReport
{
    public class GetProductSalesDetailReportQueryRequest : IRequest<List<GetProductSalesDetailReportQueryResponse>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
