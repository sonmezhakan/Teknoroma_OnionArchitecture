using AutoMapper;
using Teknoroma.Application.Features.Branches.Command.Create;
using Teknoroma.Application.Features.Branches.Command.Update;
using Teknoroma.Application.Features.Branches.Models;
using Teknoroma.Application.Features.Branches.Queries.GetAll;
using Teknoroma.Application.Features.Branches.Queries.GetById;
using Teknoroma.Application.Features.Products.Queries.GetById;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Branches.Profiles
{
	public class MapperProfiles:Profile
	{
        public MapperProfiles()
        {
            CreateMap<Branch, CreateBranchCommandRequest>().ReverseMap();
            CreateMap<Branch, UpdateBranchCommandRequest>().ReverseMap();

            CreateMap<Branch, GetByIdBranchQueryResponse>().ReverseMap();
            CreateMap<Branch,GetAllBranchQueryResponse>().ReverseMap();

            CreateMap<CreateBranchViewModel, CreateBranchCommandRequest>().ReverseMap();
            CreateMap<BranchViewModel,UpdateBranchCommandRequest>().ReverseMap();
            CreateMap<BranchViewModel, GetByIdBranchQueryResponse>().ReverseMap();
            CreateMap<BranchViewModel,GetAllBranchQueryResponse>().ReverseMap();
            CreateMap<BranchListViewModel, GetAllBranchQueryResponse>().ReverseMap();

            CreateMap<CreateBranchViewModel, BranchViewModel>().ReverseMap();
        }
    }
}
