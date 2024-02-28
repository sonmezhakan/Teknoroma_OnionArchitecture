using MediatR;

namespace Teknoroma.Application.Features.Categories.Queries.GetCategoryEarningReport
{
    public class GetCategoryEarningReportQueryRequest:IRequest<List<GetCategoryEarningReportQueryResponse>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
