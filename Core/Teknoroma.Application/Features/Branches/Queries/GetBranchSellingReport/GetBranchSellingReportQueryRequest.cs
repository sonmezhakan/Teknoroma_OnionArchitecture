using MediatR;

namespace Teknoroma.Application.Features.Branches.Queries.GetBranchSellingReport
{
    public class GetBranchSellingReportQueryRequest:IRequest<List<GetBranchSellingReportQueryResponse>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
