using AutoMapper;
using Teknoroma.Application.Features.AppUserRoles.Command.Create;
using Teknoroma.Application.Features.AppUserRoles.Command.Update;
using Teknoroma.Application.Features.AppUserRoles.Models;
using Teknoroma.Application.Features.AppUserRoles.Queries.GetById;
using Teknoroma.Application.Features.AppUserRoles.Queries.GetList;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.AppUserRoles.Profiles
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<AppUserRole, CreateAppUserRoleCommandRequest>().ReverseMap();
            CreateMap<AppUserRole, UpdateAppUserRoleCommandRequest>().ReverseMap();
            CreateMap<AppUserRole, GetByIdAppUserRoleQueryResponse>().ReverseMap();
            CreateMap<AppUserRole, GetAllAppUserRoleQueryResponse>().ReverseMap();

            CreateMap<CreateAppUserRoleViewModel, CreateAppUserRoleCommandRequest>().ReverseMap();
            CreateMap<AppUserRoleViewModel, UpdateAppUserRoleCommandRequest>().ReverseMap();
            CreateMap<AppUserRoleViewModel, GetByIdAppUserRoleQueryResponse>().ReverseMap();
            CreateMap<AppUserRoleViewModel, GetAllAppUserRoleQueryResponse>().ReverseMap();
        }
    }
}
