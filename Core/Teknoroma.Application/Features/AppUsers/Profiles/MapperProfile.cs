using AutoMapper;
using Teknoroma.Application.Features.AppUsers.Command.Create;
using Teknoroma.Application.Features.AppUsers.Command.Update;
using Teknoroma.Application.Features.AppUsers.Models;
using Teknoroma.Application.Features.AppUsers.Queries.GetById;
using Teknoroma.Application.Features.AppUsers.Queries.GetByUserName;
using Teknoroma.Application.Features.AppUsers.Queries.GetList;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.AppUsers.Profiles
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<AppUser, GetByUserNameAppUserQueryResponse>().ReverseMap();
            CreateMap<AppUser, CreateAppUserCommandRequest>().ReverseMap();
            CreateMap<AppUser, UpdateAppUserCommandRequest>().ReverseMap();
            CreateMap<AppUser, GetByIdAppUserQueryResponse>().ReverseMap();
            CreateMap<AppUser, GetAllAppUserQueryResponse>().ReverseMap();

            CreateMap<CreateAppUserViewModel, CreateAppUserCommandRequest>().ReverseMap();
            CreateMap<AppUserViewModel, UpdateAppUserCommandRequest>().ReverseMap();
            CreateMap<AppUserViewModel, GetByIdAppUserQueryResponse>().ReverseMap();
            CreateMap<AppUserViewModel, GetAllAppUserQueryResponse>().ReverseMap();
        }
    }
}
