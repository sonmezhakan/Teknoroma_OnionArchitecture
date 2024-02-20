using AutoMapper;
using Teknoroma.Application.Features.AppUsers.Queries.GetByUserName;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.AppUsers.Profiles
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<AppUser, GetByUserNameAppUserQueryResponse>().ReverseMap();
        }
    }
}
