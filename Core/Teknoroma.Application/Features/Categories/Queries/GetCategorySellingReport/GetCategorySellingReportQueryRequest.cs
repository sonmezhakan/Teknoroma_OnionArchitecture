using MediatR;

namespace Teknoroma.Application.Features.Categories.Queries.GetCategorySellingReport
{
    public class GetCategorySellingReportQueryRequest:IRequest<List<GetCategorySellingReportQueryResponse>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
