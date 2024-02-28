﻿using MediatR;
using Teknoroma.Application.Repositories;

namespace Teknoroma.Application.Features.Products.Queries.GetProductEarningReport
{
	public class GetProductEarningReportQueryHandler : IRequestHandler<GetProductEarningReportQueryRequest, List<GetProductEarningReportQueryResponse>>
	{
		private readonly IProductRepository _productRepository;

		public GetProductEarningReportQueryHandler(IProductRepository productRepository)
        {
			_productRepository = productRepository;
		}
        public async Task<List<GetProductEarningReportQueryResponse>> Handle(GetProductEarningReportQueryRequest request, CancellationToken cancellationToken)
		{
			var products = await _productRepository.GetAllAsync();

			var bestSellingProduct = products.GroupBy(product => product.ProductName)
				.Select(grouped => new
				{
					ProductName = grouped.Key,
					TotalPrice = grouped.Select(orderDetails => orderDetails.OrderDetails
					.Where(x => x.IsActive == true &&
					x.Order.OrderDate >= request.StartDate && x.Order.OrderDate <= request.EndDate))
					.SelectMany(details => details).Sum(detail => detail.UnitPrice * detail.Quantity)
				})
				.OrderByDescending(x => x.TotalPrice).ToList();

			return new List<GetProductEarningReportQueryResponse>(bestSellingProduct.Select(x => new GetProductEarningReportQueryResponse
			{
				ProductName = x.ProductName,
				TotalPrice = x.TotalPrice
			}).ToList());
		}
	}
}