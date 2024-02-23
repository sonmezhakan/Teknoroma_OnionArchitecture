using AutoMapper;
using Teknoroma.Application.Features.OrderDetails.Command.Create;
using Teknoroma.Application.Features.Orders.Command.Create;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Orders.Profiles
{
	public class MapperProfile:Profile
	{
        public MapperProfile()
        {
            CreateMap<Order, CreateOrderCommandRequest>().ReverseMap();
            
        }
    }
}
