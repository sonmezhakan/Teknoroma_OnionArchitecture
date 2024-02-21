using AutoMapper;
using Teknoroma.Application.Features.AppUserProfiles.Command.Create;
using Teknoroma.Application.Features.AppUserProfiles.Command.Update;
using Teknoroma.Application.Features.AppUserProfiles.Quıeries.GetById;
using Teknoroma.Application.Features.AppUserProfiles.Quıeries.GetList;
using Teknoroma.Application.Features.AppUsers.Command.Create;
using Teknoroma.Application.Features.AppUsers.Command.Update;
using Teknoroma.Application.Features.AppUsers.Queries.GetById;
using Teknoroma.Application.Features.AppUsers.Queries.GetList;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.AppUserProfiles.Profiles
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<AppUserProfile, CreateAppUserProfileCommandRequest>().ReverseMap();
            CreateMap<AppUserProfile, UpdateAppUserProfileCommandRequest>().ReverseMap();
            CreateMap<AppUserProfile, GetByIdAppUserProfileQueryResponse>().ReverseMap();
            CreateMap<AppUserProfile, GetAllAppUserQueryResponse>().ReverseMap();
            CreateMap<AppUserProfile, GetAllAppUserProfileQueryResponse>().ReverseMap();

            CreateMap<CreateAppUserProfileCommandRequest, CreateAppUserCommandRequest>().ReverseMap();
            CreateMap<UpdateAppUserProfileCommandRequest, UpdateAppUserCommandRequest>().ReverseMap();

            CreateMap<GetByIdAppUserQueryResponse, GetByIdAppUserProfileQueryResponse>().ReverseMap();
        }
    }
}
