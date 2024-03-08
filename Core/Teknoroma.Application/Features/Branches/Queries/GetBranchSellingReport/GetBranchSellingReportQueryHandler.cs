using MediatR;
using Teknoroma.Application.Services.Branches;

namespace Teknoroma.Application.Features.Branches.Queries.GetBranchSellingReport
{
	public class GetBranchSellingReportQueryHandler : IRequestHandler<GetBranchSellingReportQueryRequest, List<GetBranchSellingReportQueryResponse>>
    {
		private readonly IBranchService _branchService;

		public GetBranchSellingReportQueryHandler(IBranchService branchService)
        {
			_branchService = branchService;
		}
        public async Task<List<GetBranchSellingReportQueryResponse>> Handle(GetBranchSellingReportQueryRequest request, CancellationToken cancellationToken)
        {
            var branches = await _branchService.GetAllAsync();

            var bestSellingBranches = branches.GroupBy(branch => branch.BranchName)
                .Select(grouped => new
                {
                    BranchName = grouped.Key,
                    TotalSales = grouped.SelectMany(orders => orders.Orders
                    .SelectMany(orderDetails => orderDetails.OrderDetails
                    .Where(x => x.IsActive == true &&
                    x.Order.OrderDate >= request.StartDate && x.Order.OrderDate <= request.EndDate)
                    .Select(orderDetail => orderDetail.Quantity)))
                    .Sum()
                }).OrderByDescending(x => x.TotalSales).ToList();

            return new List<GetBranchSellingReportQueryResponse>(bestSellingBranches.Select(x => new GetBranchSellingReportQueryResponse
            {
                BranchName = x.BranchName,
                TotalSales = x.TotalSales
            }));
        }
    }
}
