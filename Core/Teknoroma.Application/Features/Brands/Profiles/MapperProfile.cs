using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Features.Brands.Command.Create;
using Teknoroma.Application.Features.Brands.Command.Update;
using Teknoroma.Application.Features.Brands.Models;
using Teknoroma.Application.Features.Brands.Quries.GetById;
using Teknoroma.Application.Features.Brands.Quries.GetList;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Brands.Profiles
{
	public class MapperProfile : Profile
	{
		public MapperProfile()
		{
			CreateMap<Brand, CreateBrandCommandRequest>().ReverseMap();
			CreateMap<Brand, UpdateBrandCommandRequest>().ReverseMap();
			CreateMap<Brand, GetByIdBrandQueryResponse>().ReverseMap();
			CreateMap<Brand, GetAllBrandCommandResponse>().ReverseMap();

			CreateMap<CreateBrandViewModel, CreateBrandCommandRequest>().ReverseMap();
			CreateMap<BrandViewModel, UpdateBrandCommandRequest>().ReverseMap();

			CreateMap<BrandViewModel, GetByIdBrandQueryResponse>().ReverseMap();
			CreateMap<BrandViewModel, GetAllBrandCommandResponse>().ReverseMap();

			
		}
	}
}
