﻿using MediatR;
using Teknoroma.Application.Services.Repositories;

namespace Teknoroma.Application.Features.Products.Queries.GetProductSupplyDetailReport
{
	public class GetProductSupplyDetailReportQueryHandler : IRequestHandler<GetProductSupplyDetailReportQueryRequest, List<GetProductSupplyDetailReportQueryResponse>>
	{
		private readonly IProductRepository _productRepository;

		public GetProductSupplyDetailReportQueryHandler(IProductRepository productRespository)
        {
			_productRepository = productRespository;
		}
        public async Task<List<GetProductSupplyDetailReportQueryResponse>> Handle(GetProductSupplyDetailReportQueryRequest request, CancellationToken cancellationToken)
		{
			var products = await _productRepository.GetAllAsync();

			List<GetProductSupplyDetailReportQueryResponse> getProductSupplyDetailReportQueryReponses = new List<GetProductSupplyDetailReportQueryResponse>();


			foreach (var product in products.ToList())
			{
				foreach (var stockInput in product.StockInputs.Where(x=>x.IsActive == true && x.StockEntryDate >= request.StartDate && x.StockEntryDate <= request.EndDate).ToList())
				{
					getProductSupplyDetailReportQueryReponses.Add(new GetProductSupplyDetailReportQueryResponse
					{
						ProductId = product.ID,
						BranchName = stockInput.Branch.BranchName,
						BrandName = product.Brand.BrandName,
						CategoryName = product.Category.CategoryName,
						CompanyName = stockInput.Supplier.CompanyName,
						InvoiceNumber = stockInput.InoviceNumber,
						ProductName = product.ProductName,
						Quantity = stockInput.Quantity,
						StockEntryDate = stockInput.StockEntryDate,
						UserName = stockInput.AppUser.UserName
					});
				}
			}

			return getProductSupplyDetailReportQueryReponses;
		}
	}
}
