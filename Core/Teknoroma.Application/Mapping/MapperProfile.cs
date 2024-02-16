using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.DTOs.AccountDTOs;
using Teknoroma.Application.Features.Branches.Models;
using Teknoroma.Application.Features.BranchProducts.Models;
using Teknoroma.Application.Features.Brands.Models;
using Teknoroma.Application.Features.Categories.Commands.Create;
using Teknoroma.Application.Features.Categories.DTO;
using Teknoroma.Application.Features.Categories.Models;
using Teknoroma.Application.Features.Customers.Models;
using Teknoroma.Application.Features.Departments.Models;
using Teknoroma.Application.Features.Products.Models;
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
