using MediatR;
using Teknoroma.Application.Services.Branches;

namespace Teknoroma.Application.Features.Branches.Queries.GetBranchEarningReport
{
	public class GetBranchEarningReportQueryHandler : IRequestHandler<GetBranchEarningReportQueryRequest, List<GetBranchEarningReportQueryResponse>>
    {
		private readonly IBranchService _branchService;

		public GetBranchEarningReportQueryHandler(IBranchService branchService)
        {
			_branchService = branchService;
		}
        public async Task<List<GetBranchEarningReportQueryResponse>> Handle(GetBranchEarningReportQueryRequest request, CancellationToken cancellationToken)
        {
            var branches = await _branchService.GetAllAsync();

            var bestEarningBranches = branches.GroupBy(branch => branch.BranchName)
                .Select(grouped => new
                {
                    BranchName = grouped.Key,
                    TotalPrice = grouped.SelectMany(orders => orders.Orders
                    .SelectMany(orderDetail => orderDetail.OrderDetails
                    .Where(x => x.IsActive == true &&
                    x.Order.OrderDate >= request.StartDate && x.Order.OrderDate <= request.EndDate)
                    .Select(orderDetail => orderDetail.Quantity * orderDetail.UnitPrice)))
                    .Sum()
                }).OrderByDescending(x => x.TotalPrice).ToList();

            return new List<GetBranchEarningReportQueryResponse>(bestEarningBranches.Select(x => new GetBranchEarningReportQueryResponse
            {
                BranchName = x.BranchName,
                TotalPrice = x.TotalPrice
            }));
        }
    }
}
