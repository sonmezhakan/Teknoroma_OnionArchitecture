using AutoMapper;
using Teknoroma.Application.Features.Stocks.Command.Create;
using Teknoroma.Application.Features.Stocks.Command.Update;
using Teknoroma.Application.Features.Stocks.Models;
using Teknoroma.Application.Features.Stocks.Queries.GetByBranchId;
using Teknoroma.Application.Features.Stocks.Queries.GetById;
using Teknoroma.Application.Features.Stocks.Queries.GetList;
using Teknoroma.Application.Features.Stocks.Queries.GetStockTrackingReportList;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Stocks.Profiles
{
	public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<Stock, CreateStockCommandRequest>().ReverseMap();
            CreateMap<Stock, UpdateStockCommandRequest>().ReverseMap();

            CreateMap<Stock, GetByBranchIdStockQueryResponse>().ReverseMap();
            CreateMap<Stock, GetByIdStockQueryResponse>().ReverseMap();

            CreateMap<Stock, GetAllStockQueryResponse>()
				.ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
				.ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.Product.UnitPrice))
				.ForMember(dest => dest.CriticalStock, opt => opt.MapFrom(src => src.Product.CriticalStock))
				.ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.Product.ImagePath))
				.ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Product.Brand.BrandName))
				.ReverseMap();
            CreateMap<StockListViewModel, GetAllStockQueryResponse>().ReverseMap();

            CreateMap<GetByIdStockQueryResponse, UpdateStockCommandRequest>().ReverseMap();

            CreateMap<Stock, GetStockTrackingReportListQueryResponse>()
                .ForMember(dest=>dest.ProductName, opt=>opt.MapFrom(src=>src.Product.ProductName))
                .ForMember(dest=>dest.CategoryName, opt=>opt.MapFrom(src=>src.Product.Category.CategoryName))
                .ForMember(dest=>dest.BrandName , opt=>opt.MapFrom(src=>src.Product.Brand.BrandName))
                .ForMember(dest=>dest.UnitPrice, opt=>opt.MapFrom(src=>src.Product.UnitPrice))
                .ForMember(dest=>dest.ImagePath , opt=>opt.MapFrom(src=>src.Product.ImagePath))
                .ForMember(dest=>dest.CriticalStock, opt=>opt.MapFrom(src=>src.Product.CriticalStock))
                .ReverseMap();

            CreateMap<StockTrackingReportViewModel, GetStockTrackingReportListQueryResponse>().ReverseMap();
        }
    }
}
