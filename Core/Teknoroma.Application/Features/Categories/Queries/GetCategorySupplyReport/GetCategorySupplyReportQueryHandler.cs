using MediatR;
using Teknoroma.Application.Features.Categories.Queries.GetCategoryEarningReport;
using Teknoroma.Application.Repositories;

namespace Teknoroma.Application.Features.Categories.Queries.GetCategorySupplyReport
{
    public class GetCategorySupplyReportQueryHandler : IRequestHandler<GetCategorySupplyReportQueryRequest, List<GetCategorySupplyReportQueryResponse>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategorySupplyReportQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<List<GetCategorySupplyReportQueryResponse>> Handle(GetCategorySupplyReportQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync();

            var bestSupplyCategories = categories.GroupBy(category => category.CategoryName)
                .Select(grouped => new
                { 
                    CategoryName = grouped.Key,
                    TotalSupply = grouped.SelectMany(products=>products.Products
                    .SelectMany(stockInputs=> stockInputs.StockInputs
                    .Where(x=>x.IsActive == true &&
                    x.StockEntryDate >= request.StartDate && x.StockEntryDate <= request.EndDate)
                    .Select(stockInput=>stockInput.Quantity)))
                    .Sum()
                }).OrderByDescending(x=>x.TotalSupply).ToList();

            return new List<GetCategorySupplyReportQueryResponse>(bestSupplyCategories.Select(x => new GetCategorySupplyReportQueryResponse
            {
                CategoryName = x.CategoryName,
                TotalSupply = x.TotalSupply
            })).ToList();
        }
    }
}
