using MediatR;

namespace Teknoroma.Application.Features.Products.Queries.GetProductSupplyReport
{
    public class GetProductSupplyReportQueryRequest:IRequest<List<GetProductSupplyReportQueryResponse>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
