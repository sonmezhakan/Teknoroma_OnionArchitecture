using MediatR;
using Teknoroma.Application.Repositories;

namespace Teknoroma.Application.Features.Products.Queries.GetProductSellingReport
{
	public class GetProductSellingReportQueryHandler : IRequestHandler<GetProductSellingReportQueryRequest, List<GetProductSellingReportQueryResponse>>
	{
		private readonly IProductRepository _productRepository;

		public GetProductSellingReportQueryHandler(IProductRepository productRepository)
        {
			_productRepository = productRepository;
		}
        public async Task<List<GetProductSellingReportQueryResponse>> Handle(GetProductSellingReportQueryRequest request, CancellationToken cancellationToken)
		{
			var products = await _productRepository.GetAllAsync();

			var bestSellingProduct = products.GroupBy(product => product.ProductName)
				.Select(grouped => new
				{
					ProductName = grouped.Key,
					TotalSales = grouped.Select(orderDetails => orderDetails.OrderDetails
					.Where(x => x.IsActive == true &&
					x.Order.OrderDate >= request.StartDate && x.Order.OrderDate <= request.EndDate))
					.SelectMany(details => details).Sum(detail => detail.Quantity)
				}).OrderByDescending(x => x.TotalSales).ToList();

			return new List<GetProductSellingReportQueryResponse>(bestSellingProduct.Select(x => new GetProductSellingReportQueryResponse
			{
				ProductName = x.ProductName,
				TotalSales = x.TotalSales
			}).ToList());
		}
	}
}
