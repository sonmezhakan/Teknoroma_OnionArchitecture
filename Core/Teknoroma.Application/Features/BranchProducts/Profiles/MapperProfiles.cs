using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Features.Branches.Command.Create;
using Teknoroma.Application.Features.BranchProducts.Command.Create;
using Teknoroma.Application.Features.BranchProducts.Command.Update;
using Teknoroma.Application.Features.BranchProducts.Models;
using Teknoroma.Application.Features.BranchProducts.Queries.GetByBranchId;
using Teknoroma.Application.Features.BranchProducts.Queries.GetById;
using Teknoroma.Application.Features.BranchProducts.Queries.GetList;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.BranchProducts.Profiles
{
	public class MapperProfiles:Profile
	{
        public MapperProfiles()
        {
            CreateMap<BranchProduct, CreateBranchProductCommandRequest>().ReverseMap();
            CreateMap<BranchProduct, UpdateBranchProductCommandRequest>().ReverseMap();

            CreateMap<BranchProduct, GetByBranchIdBranchProductQueryResponse>().ReverseMap();
            CreateMap<BranchProduct, GetByIdBranchProductQueryResponse>().ReverseMap();

            CreateMap<BranchProduct, GetAllBranchProductQueryResponse>()
                .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch.BranchName))
                .ForMember(dest=>dest.ProductName, opt=>opt.MapFrom(src=>src.Product.ProductName))
                .ForMember(dest=>dest.UnitPrice, opt=>opt.MapFrom(src=>src.Product.UnitPrice))
                .ForMember(dest=>dest.CriticalStock, opt=>opt.MapFrom(src=>src.Product.CriticalStock))
                .ReverseMap();
            CreateMap<BranchProductListViewModel, GetAllBranchProductQueryResponse>().ReverseMap();
        }
    }
}
