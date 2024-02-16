using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Features.Branches.Command.Create;
using Teknoroma.Application.Features.Branches.Command.Update;
using Teknoroma.Application.Features.Branches.Models;
using Teknoroma.Application.Features.Branches.Queries.GetAll;
using Teknoroma.Application.Features.Branches.Queries.GetById;
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
        }
    }
}
