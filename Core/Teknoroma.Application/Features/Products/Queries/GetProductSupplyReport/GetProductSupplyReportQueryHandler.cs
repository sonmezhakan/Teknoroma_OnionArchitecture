using MediatR;
using Teknoroma.Application.Services.Products;

namespace Teknoroma.Application.Features.Products.Queries.GetProductSupplyReport
{
	public class GetProductSupplyReportQueryHandler : IRequestHandler<GetProductSupplyReportQueryRequest, List<GetProductSupplyReportQueryResponse>>
    {
		private readonly IProductService _productService;

		public GetProductSupplyReportQueryHandler(IProductService productService)
        {
			_productService = productService;
		}
        public async Task<List<GetProductSupplyReportQueryResponse>> Handle(GetProductSupplyReportQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _productService.GetAllAsync();

            var bestSupplyProduct = products.GroupBy(product => product.ID)
                .Select(grouped => new
                {
                    ProductId = grouped.Key,
                    ProductName = grouped.Select(product=>product.ProductName).First(),
                    TotalSupply = grouped.Select(stockInputs => stockInputs.StockInputs
                    .Where(x => x.IsActive == true &&
                    x.StockEntryDate >= request.StartDate && x.StockEntryDate <= request.EndDate))
                    .SelectMany(stockInputs => stockInputs).Sum(stockInput => stockInput.Quantity)
                })
                .OrderByDescending(x => x.TotalSupply).ToList();

            return new List<GetProductSupplyReportQueryResponse>(bestSupplyProduct.Select(x => new GetProductSupplyReportQueryResponse
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                TotalSupply = x.TotalSupply
            }).ToList());
        }
    }
}
