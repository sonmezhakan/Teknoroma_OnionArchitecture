using AutoMapper;
using Teknoroma.Application.Features.Products.Command.Create;
using Teknoroma.Application.Features.Products.Command.Update;
using Teknoroma.Application.Features.Products.Models;
using Teknoroma.Application.Features.Products.Queries.GetById;
using Teknoroma.Application.Features.Products.Queries.GetList;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Products.Profiles
{
	public class MapperProfile:Profile
	{
        public MapperProfile()
        {
			CreateMap<Product, CreateProductCommandRequest>().ReverseMap();
			CreateMap<Product,UpdateProductCommandRequest>().ReverseMap();
			CreateMap<Product, GetByIdProductQueryResponse>().ReverseMap();

			CreateMap<CreateProductViewModel,CreateProductCommandRequest>().ReverseMap();
			CreateMap<ProductViewModel, UpdateProductCommandRequest>().ReverseMap();

			CreateMap<ProductViewModel, GetByIdProductQueryResponse>().ReverseMap();
			CreateMap<ProductListViewModel,GetAllProductQueryResponse>().ReverseMap();

			CreateMap<Product, GetAllProductQueryResponse>()
				.ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName))
				.ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.BrandName))
				.ReverseMap();
		}
    }
}
