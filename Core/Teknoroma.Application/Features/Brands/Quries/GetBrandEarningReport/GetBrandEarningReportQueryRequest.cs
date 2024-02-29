using MediatR;

namespace Teknoroma.Application.Features.Brands.Quries.GetBrandEarningReport
{
    public class GetBrandEarningReportQueryRequest:IRequest<List<GetBrandEarningReportQueryResponse>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
