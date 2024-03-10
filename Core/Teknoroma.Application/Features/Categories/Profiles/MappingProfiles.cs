using AutoMapper;
using Teknoroma.Application.Features.Categories.Commands.Create;
using Teknoroma.Application.Features.Categories.Commands.Update;
using Teknoroma.Application.Features.Categories.Dtos;
using Teknoroma.Application.Features.Categories.Models;
using Teknoroma.Application.Features.Categories.Queries.GetById;
using Teknoroma.Application.Features.Categories.Queries.GetCategoryEarningReport;
using Teknoroma.Application.Features.Categories.Queries.GetCategorySellingReport;
using Teknoroma.Application.Features.Categories.Queries.GetCategorySupplyReport;
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

            CreateMap<CategorySellingReportViewModel, GetCategorySellingReportQueryResponse>().ReverseMap();
            CreateMap<CategoryEarningReportViewModel, GetCategoryEarningReportQueryResponse>().ReverseMap();
            CreateMap<CategorySupplyReportViewModel, GetCategorySupplyReportQueryResponse>().ReverseMap();

            CreateMap<CategoryHomePageListDto, GetAllCategoryQueryResponse>().ReverseMap();
        }
    }
}
