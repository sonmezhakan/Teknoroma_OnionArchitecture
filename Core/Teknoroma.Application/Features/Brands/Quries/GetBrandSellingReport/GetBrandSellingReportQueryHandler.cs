using MediatR;
using Teknoroma.Application.Services.Repositories;

namespace Teknoroma.Application.Features.Brands.Quries.GetBrandSellingReport
{
	public class GetBrandSellingReportQueryHandler : IRequestHandler<GetBrandSellingReportQueryRequest, List<GetBrandSellingReportQueryResponse>>
    {
		private readonly IBrandRepository _brandRepository;

		public GetBrandSellingReportQueryHandler(IBrandRepository brandRepository)
        {
			_brandRepository = brandRepository;
		}
        public async Task<List<GetBrandSellingReportQueryResponse>> Handle(GetBrandSellingReportQueryRequest request, CancellationToken cancellationToken)
        {
            var brands = await _brandRepository.GetAllAsync();

            var bestSellingBrands = brands.GroupBy(brand => brand.BrandName)
                .Select(grouped => new
                {
                    BrandName = grouped.Key,
                    TotalSales = grouped.SelectMany(products => products.Products
                    .SelectMany(orderDetails => orderDetails.OrderDetails
                    .Where(x=>x.IsActive == true &&
                    x.Order.OrderDate >= request.StartDate && x.Order.OrderDate <= request.EndDate)
                    .Select(orderDetail => orderDetail.Quantity)))
                    .Sum()
                }).OrderByDescending(x => x.TotalSales).ToList();

            return new List<GetBrandSellingReportQueryResponse>(bestSellingBrands.Select(x => new GetBrandSellingReportQueryResponse
            {
                BrandName = x.BrandName,
                TotalSales = x.TotalSales
            }));
        }
    }
}
