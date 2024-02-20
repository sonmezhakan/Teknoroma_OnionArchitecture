
using AutoMapper;
using Teknoroma.Application.Features.StockInputs.Command.Create;
using Teknoroma.Application.Features.StockInputs.Command.Update;
using Teknoroma.Application.Features.StockInputs.Models;
using Teknoroma.Application.Features.StockInputs.Queries.GetById;
using Teknoroma.Application.Features.StockInputs.Queries.GetList;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.StockInputs.Profiles
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<StockInput, CreateStockInputCommandRequest>().ReverseMap();
            CreateMap<StockInput, UpdateStockInputCommandRequest>().ReverseMap();
            CreateMap<StockInput, GetByIdStockInputQueryResponse>().ReverseMap();

            CreateMap<CreateStockInputViewModel, CreateStockInputCommandRequest>().ReverseMap();
            CreateMap<StockInputViewModel, UpdateStockInputCommandRequest>().ReverseMap();
            CreateMap<StockInputViewModel, GetByIdStockInputQueryResponse>().ReverseMap();
            
            CreateMap<StockInputListViewModel, GetAllStockInputQueryResponse>().ReverseMap();
            CreateMap<StockInput, GetAllStockInputQueryResponse>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
                .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch.BranchName))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Supplier.CompanyName))
                .ForMember(dest => dest.AppUserName, opt => opt.MapFrom(src => src.AppUser.UserName))
                .ReverseMap();


        }
    }
}
