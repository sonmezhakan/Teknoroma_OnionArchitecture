using AutoMapper;
using MediatR;
using Teknoroma.Application.Repositories;

namespace Teknoroma.Application.Features.Products.Queries.GetProductSalesDetailReport
{
    public class GetProductSalesDetailReportQueryHandler : IRequestHandler<GetProductSalesDetailReportQueryRequest, List<GetProductSalesDetailReportQueryResponse>>
    {
		private readonly IMapper _mapper;
		private readonly IProductRepository _productRepository;

        public GetProductSalesDetailReportQueryHandler(IMapper mapper,IProductRepository productRepository)
        {
			_mapper = mapper;
			_productRepository = productRepository;
        }
        public async Task<List<GetProductSalesDetailReportQueryResponse>> Handle(GetProductSalesDetailReportQueryRequest request, CancellationToken cancellationToken)
        {
			var products = await _productRepository.GetAllAsync();

			List<GetProductSalesDetailReportQueryResponse> getProductDetailSalesReportQueryResponses = new List<GetProductSalesDetailReportQueryResponse>();

			foreach (var product in products.ToList())
            {
				foreach (var orderDetail in product.OrderDetails
				.Where(x => x.IsActive == true && x.Order.OrderDate >= request.StartDate && x.Order.OrderDate <= request.EndDate && x.Order.IsActive == true).ToList())
				{
					getProductDetailSalesReportQueryResponses.Add(new GetProductSalesDetailReportQueryResponse
					{
						ProductId = product.ID,
						OrderId = orderDetail.Order.ID,
						ProductName = product.ProductName,
						BrandName = product.Brand.BrandName,
						CategoryName = product.Category.CategoryName,
						UserName = orderDetail.Order.Employee.AppUser.UserName,
						BranchName = orderDetail.Order.Branch.BranchName,
						OrderDate = orderDetail.Order.OrderDate,
						Quantity = orderDetail.Quantity,
						UnitPrice = orderDetail.UnitPrice,
						TotalPrice = orderDetail.UnitPrice * orderDetail.Quantity
					});
				}
			}
			return getProductDetailSalesReportQueryResponses;
        }
    }
}
