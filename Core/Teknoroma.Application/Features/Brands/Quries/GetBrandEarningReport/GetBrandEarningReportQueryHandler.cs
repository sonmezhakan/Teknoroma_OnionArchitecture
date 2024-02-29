using MediatR;
using Teknoroma.Application.Repositories;

namespace Teknoroma.Application.Features.Brands.Quries.GetBrandEarningReport
{
    public class GetBrandEarningReportQueryHandler : IRequestHandler<GetBrandEarningReportQueryRequest, List<GetBrandEarningReportQueryResponse>>
    {
        private readonly IBrandRepository _brandRepository;

        public GetBrandEarningReportQueryHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task<List<GetBrandEarningReportQueryResponse>> Handle(GetBrandEarningReportQueryRequest request, CancellationToken cancellationToken)
        {
            var brands = await _brandRepository.GetAllAsync();

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
