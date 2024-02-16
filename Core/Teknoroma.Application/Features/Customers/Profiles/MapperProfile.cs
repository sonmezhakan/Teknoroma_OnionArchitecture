using AutoMapper;
using Teknoroma.Application.Features.Brands.Quries.GetById;
using Teknoroma.Application.Features.Customers.Command.Create;
using Teknoroma.Application.Features.Customers.Command.Update;
using Teknoroma.Application.Features.Customers.Models;
using Teknoroma.Application.Features.Customers.Queries.GetById;
using Teknoroma.Application.Features.Customers.Queries.GetList;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Customers.Profiles
{
    public class MapperProfile:Profile
	{
        public MapperProfile()
        {
			CreateMap<Customer,CreateCustomerCommandRequest>().ReverseMap();
			CreateMap<Customer,UpdateCustomerCommandRequest>().ReverseMap();
			
			CreateMap<Customer,GetByIdCustomerCommandResponse>().ReverseMap();
			CreateMap<Customer, GetAllCustomerCommandResponse>().ReverseMap();

			CreateMap<CreateCustomerViewModel, CreateCustomerCommandRequest>().ReverseMap();
			CreateMap<CustomerViewModel, UpdateCustomerCommandRequest>().ReverseMap();
			CreateMap<CustomerViewModel, GetByIdBrandCommandResponse>().ReverseMap();
			CreateMap<CustomerViewModel, GetAllCustomerCommandResponse>().ReverseMap();

		}
    }
}
