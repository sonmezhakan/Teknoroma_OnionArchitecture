using MediatR;

namespace Teknoroma.Application.Features.Brands.Quries.GetBrandSellingReport
{
    public class GetBrandSellingReportQueryRequest:IRequest<List<GetBrandSellingReportQueryResponse>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
