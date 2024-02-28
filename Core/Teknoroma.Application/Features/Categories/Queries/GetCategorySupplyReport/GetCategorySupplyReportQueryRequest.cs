using MediatR;

namespace Teknoroma.Application.Features.Categories.Queries.GetCategorySupplyReport
{
    public class GetCategorySupplyReportQueryRequest:IRequest<List<GetCategorySupplyReportQueryResponse>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
