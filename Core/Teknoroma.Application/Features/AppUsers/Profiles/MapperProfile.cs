using AutoMapper;
using Teknoroma.Application.Features.AppUsers.Command.Create;
using Teknoroma.Application.Features.AppUsers.Command.Update;
using Teknoroma.Application.Features.AppUsers.Commands.Login;
using Teknoroma.Application.Features.AppUsers.Models;
using Teknoroma.Application.Features.AppUsers.Queries.GetById;
using Teknoroma.Application.Features.AppUsers.Queries.GetByUserName;
using Teknoroma.Application.Features.AppUsers.Queries.GetList;
using Teknoroma.Application.Features.AppUsers.Queries.GetListSelectIdAndName;
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
            CreateMap<AppUser, GetByIdAppUserQueryResponse>()
                .ForMember(dest=>dest.FirstName, opt=>opt.MapFrom(src=>src.AppUserProfile.FirstName))
                .ForMember(dest=>dest.LastName, opt=>opt.MapFrom(src=>src.AppUserProfile.LastName))
                .ForMember(dest=>dest.NationalityNumber, opt=>opt.MapFrom(src=>src.AppUserProfile.NationalityNumber))
                .ForMember(dest=>dest.Address, opt=>opt.MapFrom(src=>src.AppUserProfile.Address))
                .ReverseMap();

            CreateMap<AppUser, GetAllAppUserQueryResponse>()
				.ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.AppUserProfile.FirstName))
				.ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.AppUserProfile.LastName))
				.ForMember(dest => dest.NationalityNumber, opt => opt.MapFrom(src => src.AppUserProfile.NationalityNumber))
				.ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.AppUserProfile.Address))
                .ReverseMap();

            CreateMap<CreateAppUserViewModel, CreateAppUserCommandRequest>().ReverseMap();
            CreateMap<AppUserViewModel, UpdateAppUserCommandRequest>().ReverseMap();
            CreateMap<AppUserViewModel, GetByIdAppUserQueryResponse>().ReverseMap();
            CreateMap<AppUserViewModel, GetAllAppUserQueryResponse>().ReverseMap();

            CreateMap<LoginViewModel, LoginAppUserCommandRequest>().ReverseMap();

            CreateMap<AppUser, GetAllSelectIdAndNameAppUserQueryResponse>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ReverseMap();
        }
    }
}
