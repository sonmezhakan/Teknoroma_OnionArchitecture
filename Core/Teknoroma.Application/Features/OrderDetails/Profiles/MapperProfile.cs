using AutoMapper;
using Teknoroma.Application.Features.OrderDetails.Command.Delete;
using Teknoroma.Application.Features.OrderDetails.Command.Update;
using Teknoroma.Application.Features.OrderDetails.Models;
using Teknoroma.Application.Features.OrderDetails.Queries.GetByOrderAndProductId;
using Teknoroma.Application.Features.OrderDetails.Queries.GetByProductId;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.OrderDetails.Profiles
{
	public class MapperProfile : Profile
	{
		public MapperProfile()
		{
			CreateMap<OrderDetail, OrderDetailViewModel>()
				.ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
				.ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
				.ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice))
				.ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
				.ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.UnitPrice * src.Quantity))
				.ForMember(dest=>dest.ImagePath , opt=>opt.MapFrom(src=>src.Product.ImagePath))
				.ReverseMap();

			CreateMap<OrderDetail, GetByOrderAndProductIdOrderDetailQueryResponse>().ReverseMap();
			CreateMap<OrderDetail, UpdateOrderDetailCommandRequest>().ReverseMap();
			CreateMap<OrderDetail, GetByProductIdOrderDetailQueryResponse>().ReverseMap();
		}
	}
}
