using MediatR;
using Teknoroma.Application.Services.Categories;

namespace Teknoroma.Application.Features.Categories.Queries.GetCategorySellingReport
{
	public class GetCategorySellingReportQueryHandler : IRequestHandler<GetCategorySellingReportQueryRequest, List<GetCategorySellingReportQueryResponse>>
    {
		private readonly ICategoryService _categoryService;

		public GetCategorySellingReportQueryHandler(ICategoryService categoryService)
        {
			_categoryService = categoryService;
		}
        public async Task<List<GetCategorySellingReportQueryResponse>> Handle(GetCategorySellingReportQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = await _categoryService.GetAllAsync();

            var bestSellingCategories = categories.GroupBy(category => category.CategoryName)
                .Select(grouped => new
                {
                    CategoryName = grouped.Key,
                    TotalSales = grouped.SelectMany(products => products.Products
                        .SelectMany(orderDetails => orderDetails.OrderDetails
                        .Where(x => x.IsActive == true &&
                        x.Order.OrderDate >= request.StartDate && x.Order.OrderDate <= request.EndDate)
                        .Select(orderDetail => orderDetail.Quantity)))
                        .Sum()
                }).OrderByDescending(x => x.TotalSales).ToList();

            return new List<GetCategorySellingReportQueryResponse>(bestSellingCategories.Select(x => new GetCategorySellingReportQueryResponse
            {
                CategoryName = x.CategoryName,
                TotalSales = x.TotalSales
            })).ToList();
        }
    }
}
