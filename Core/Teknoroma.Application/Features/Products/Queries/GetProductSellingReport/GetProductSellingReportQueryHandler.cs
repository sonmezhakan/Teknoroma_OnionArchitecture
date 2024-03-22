using MediatR;
using Teknoroma.Application.Services.Repositories;

namespace Teknoroma.Application.Features.Products.Queries.GetProductSellingReport
{
	public class GetProductSellingReportQueryHandler : IRequestHandler<GetProductSellingReportQueryRequest, List<GetProductSellingReportQueryResponse>>
	{
		private readonly IProductRepository _productRepository;

		public GetProductSellingReportQueryHandler(IProductRepository productRespository)
        {
			_productRepository = productRespository;
		}
        public async Task<List<GetProductSellingReportQueryResponse>> Handle(GetProductSellingReportQueryRequest request, CancellationToken cancellationToken)
		{
			var products = await _productRepository.GetAllAsync();

			var bestSellingProduct = products.GroupBy(product => product.ID)
				.Select(grouped => new
				{
					ProductId = grouped.Key,
					ProductName = grouped.Select(product=>product.ProductName).First(),
					TotalSales = grouped.Select(orderDetails => orderDetails.OrderDetails
					.Where(x => x.IsActive == true &&
					x.Order.OrderDate >= request.StartDate && x.Order.OrderDate <= request.EndDate))
					.SelectMany(details => details).Sum(detail => detail.Quantity)
				}).OrderByDescending(x => x.TotalSales).ToList();

			return new List<GetProductSellingReportQueryResponse>(bestSellingProduct.Select(x => new GetProductSellingReportQueryResponse
			{
				ProductId = x.ProductId,
				ProductName = x.ProductName,
				TotalSales = x.TotalSales
			}).ToList());
		}
	}
}
