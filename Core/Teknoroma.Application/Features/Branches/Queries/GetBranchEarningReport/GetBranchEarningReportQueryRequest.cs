using MediatR;

namespace Teknoroma.Application.Features.Branches.Queries.GetBranchEarningReport
{
    public class GetBranchEarningReportQueryRequest : IRequest<List<GetBranchEarningReportQueryResponse>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
