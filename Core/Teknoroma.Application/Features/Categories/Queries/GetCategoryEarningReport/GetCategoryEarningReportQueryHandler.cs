using MediatR;
using Teknoroma.Application.Services.Repositories;

namespace Teknoroma.Application.Features.Categories.Queries.GetCategoryEarningReport
{
	public class GetCategoryEarningReportQueryHandler : IRequestHandler<GetCategoryEarningReportQueryRequest, List<GetCategoryEarningReportQueryResponse>>
    {
        private readonly ICategoryRepository _categoryRepository;

		public GetCategoryEarningReportQueryHandler(ICategoryRepository categoryRepository)
        {
			_categoryRepository = categoryRepository;
		}
        public async Task<List<GetCategoryEarningReportQueryResponse>> Handle(GetCategoryEarningReportQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync();

            var bestEarningCategories = categories.GroupBy(category => category.CategoryName)
                .Select(grouped => new
                {
                    CategoryName = grouped.Key,
                    TotalPrice = grouped.SelectMany(products => products.Products
                        .SelectMany(orderDetails => orderDetails.OrderDetails
                        .Where(x => x.IsActive == true &&
                        x.Order.OrderDate >= request.StartDate && x.Order.OrderDate <= request.EndDate)
                        .Select(orderDetail => orderDetail.Quantity * orderDetail.UnitPrice)))
                        .Sum()
                }).OrderByDescending(x => x.TotalPrice).ToList();

            return new List<GetCategoryEarningReportQueryResponse>(bestEarningCategories.Select(x => new GetCategoryEarningReportQueryResponse
            {
                CategoryName = x.CategoryName,
                TotalPrice = x.TotalPrice
            })).ToList();
        }
    }
}
