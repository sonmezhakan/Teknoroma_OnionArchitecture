using MediatR;
using Teknoroma.Application.Services.Brands;

namespace Teknoroma.Application.Features.Brands.Quries.GetBrandEarningReport
{
	public class GetBrandEarningReportQueryHandler : IRequestHandler<GetBrandEarningReportQueryRequest, List<GetBrandEarningReportQueryResponse>>
    {
		private readonly IBrandService _brandService;

		public GetBrandEarningReportQueryHandler(IBrandService brandService)
        {
			_brandService = brandService;
		}
        public async Task<List<GetBrandEarningReportQueryResponse>> Handle(GetBrandEarningReportQueryRequest request, CancellationToken cancellationToken)
        {
            var brands = await _brandService.GetAllAsync();

            var bestEarningBrands = brands.GroupBy(brand => brand.BrandName)
                .Select(grouped => new
                {
                    BrandName = grouped.Key,
                    TotalPrice = grouped.SelectMany(products => products.Products
                    .SelectMany(orderDetails => orderDetails.OrderDetails
                    .Where(x => x.IsActive == true &&
                    x.Order.OrderDate >= request.StartDate && x.Order.OrderDate <= request.EndDate)
                    .Select(orderDetails => orderDetails.Quantity * orderDetails.UnitPrice)))
                    .Sum()
                }).OrderByDescending(x => x.TotalPrice).ToList();

            return new List<GetBrandEarningReportQueryResponse>(bestEarningBrands.Select(x => new GetBrandEarningReportQueryResponse
            {
                BrandName = x.BrandName,
                TotalPrice = x.TotalPrice
            }));
        }
    }
}
