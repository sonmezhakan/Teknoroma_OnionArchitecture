using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Features.Categories.Commands.Create;
using Teknoroma.Application.Features.Categories.Commands.Update;
using Teknoroma.Application.Features.Categories.Models;
using Teknoroma.Application.Features.Categories.Queries.GetById;
using Teknoroma.Application.Features.Categories.Queries.GetList;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Categories.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Category, CreateCategoryCommandRequest>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommandRequest>().ReverseMap();

            CreateMap<Category, GetAllCategoryQueryResponse>().ReverseMap();
            CreateMap<Category,GetByIdCategoryQueryResponse>().ReverseMap();

            CreateMap<CreateCategoryViewModel, CreateCategoryCommandRequest>().ReverseMap();
            CreateMap<CategoryViewModel, UpdateCategoryCommandRequest>().ReverseMap();
            CreateMap<CategoryViewModel, GetByIdCategoryQueryResponse>().ReverseMap();
            CreateMap<CategoryViewModel,GetAllCategoryQueryResponse>().ReverseMap();
        }
    }
}
