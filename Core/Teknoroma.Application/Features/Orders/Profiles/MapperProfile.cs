using AutoMapper;
using Teknoroma.Application.Features.Orders.Command.Create;
using Teknoroma.Application.Features.Orders.Command.Update;
using Teknoroma.Application.Features.Orders.Models;
using Teknoroma.Application.Features.Orders.Queries.GetByBranchIdList;
using Teknoroma.Application.Features.Orders.Queries.GetById;
using Teknoroma.Application.Features.Orders.Queries.GetList;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Orders.Profiles
{
	public class MapperProfile:Profile
	{
        public MapperProfile()
        {
            CreateMap<Order, CreateOrderCommandRequest>().ReverseMap();
			CreateMap<Order, GetByIdOrderQueryResponse>().ReverseMap();
            CreateMap<Order, UpdateOrderCommandRequest>().ReverseMap();   
            
			CreateMap<Order, GetByBranchIdOrderListQueryResponse>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Employee.AppUser.UserName))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FullName))
                .ForMember(dest => dest.CustomerPhoneNumber, opt => opt.MapFrom(src => src.Customer.PhoneNumber))
                .ForMember(dest => dest.OrderStatu, opt => opt.MapFrom(src => src.OrderStatu))
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate))
                .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch.BranchName))
                .AfterMap((src, dest) => dest.TotalProductQuantity = src.OrderDetails.Sum(od=>od.Quantity))
                .AfterMap((src, dest) => dest.TotalPrice = src.OrderDetails.Sum(od => od.UnitPrice * od.Quantity))
				.ForMember(dest => dest.OrderDetailViewModels, opt => opt.MapFrom(src => src.OrderDetails))
				.ReverseMap();

            CreateMap<Order,GetAllOrderQueryResponse>()
				.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Employee.AppUser.UserName))
				.ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FullName))
				.ForMember(dest => dest.CustomerPhoneNumber, opt => opt.MapFrom(src => src.Customer.PhoneNumber))
				.ForMember(dest => dest.OrderStatu, opt => opt.MapFrom(src => src.OrderStatu))
				.ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate))
				.ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch.BranchName))
				.AfterMap((src, dest) => dest.TotalProductQuantity = src.OrderDetails.Sum(od => od.Quantity))
				.AfterMap((src, dest) => dest.TotalPrice = src.OrderDetails.Sum(od => od.UnitPrice * od.Quantity))
				.ReverseMap();

			CreateMap<GetByIdOrderQueryResponse, UpdateOrderCommandRequest>().ReverseMap();

			CreateMap<OrderListViewModel, GetByBranchIdOrderListQueryResponse>().ReverseMap();
            CreateMap<OrderListViewModel, GetAllOrderQueryResponse>().ReverseMap();

            
		}
    }
}
