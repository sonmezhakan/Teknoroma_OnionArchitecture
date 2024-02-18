using AutoMapper;
using Teknoroma.Application.DTOs.AccountDTOs;
using Teknoroma.Application.ViewModel;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Mapping
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            #region AppUser
            CreateMap<AppUser, LoginDTO>().ReverseMap();

            CreateMap<AppUser, RegisterDTO>().ReverseMap();

            CreateMap<RegisterDTO, RegisterViewModel>().ReverseMap();

            CreateMap<LoginDTO, LoginViewModel>().ReverseMap();
            #endregion
        }
    }
}
