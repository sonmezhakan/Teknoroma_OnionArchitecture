using AutoMapper;
using Teknoroma.Application.Features.TechnicalProblems.Commands.Create;
using Teknoroma.Application.Features.TechnicalProblems.Commands.Update;
using Teknoroma.Application.Features.TechnicalProblems.Models;
using Teknoroma.Application.Features.TechnicalProblems.Queries.GetById;
using Teknoroma.Application.Features.TechnicalProblems.Queries.GetList;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.TechnicalProblems.Profiles
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<TechnicalProblem, CreateTechnicalProblemCommandRequest>().ReverseMap();
            CreateMap<TechnicalProblem, UpdateTechnicalProblemCommandRequest>().ReverseMap();
            CreateMap<TechnicalProblem, GetByIdTechnicalProblemQueryResponse>()
                .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch.BranchName))
				.ForMember(dest => dest.AppUserName, opt => opt.MapFrom(src => src.Employee.AppUser.UserName))
				.ReverseMap();
			CreateMap<TechnicalProblem, GetAllTechnicalProblemQueryResponse>()
                .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch.BranchName))
                .ForMember(dest=>dest.AppUserName, opt=>opt.MapFrom(src=>src.Employee.AppUser.UserName))
                .ReverseMap();

            CreateMap<CreateTechnicalProblemViewModel, CreateTechnicalProblemCommandRequest>().ReverseMap();
            CreateMap<TechnicalProblemViewModel, UpdateTechnicalProblemCommandRequest>().ReverseMap();
            CreateMap<TechnicalProblemViewModel, GetByIdTechnicalProblemQueryResponse>().ReverseMap();
            CreateMap<TechnicalProblemViewModel, GetAllTechnicalProblemQueryResponse>().ReverseMap();
		}
    }
}
