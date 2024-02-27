using AutoMapper;
using Teknoroma.Application.Features.Reports.SalesReport.Models;
using Teknoroma.Application.Features.Reports.SalesReport.Queries.GetSalesReport;

namespace Teknoroma.Application.Features.Reports.SalesReport.Profiles
{
	public class MapperProfile:Profile
	{
        public MapperProfile()
        {
            CreateMap<SalesReportViewModel,  GetSalesReportQueryResponse>().ReverseMap();
        }
    }
}
