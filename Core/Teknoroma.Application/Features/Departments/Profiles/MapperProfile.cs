using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Features.Departments.Command.Create;
using Teknoroma.Application.Features.Departments.Command.Update;
using Teknoroma.Application.Features.Departments.Models;
using Teknoroma.Application.Features.Departments.Queries.GetById;
using Teknoroma.Application.Features.Departments.Queries.GetList;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Departments.Profiles
{
    public class MapperProfile:Profile
	{
        public MapperProfile()
        {
            CreateMap<Department,CreateDepartmentCommandRequest>().ReverseMap();
            CreateMap<Department,UpdateDepartmentCommandRequest>().ReverseMap();

            CreateMap<Department,GetByIdDepartmentQueryResponse>().ReverseMap();
            CreateMap<Department,GetAllDepartmentQueryResponse>().ReverseMap();

            CreateMap<CreateDepartmentViewModel, CreateDepartmentCommandRequest>().ReverseMap();
            CreateMap<DepartmentViewModel, GetByIdDepartmentQueryResponse>().ReverseMap();
			CreateMap<DepartmentViewModel, GetAllDepartmentQueryResponse>().ReverseMap();
			CreateMap<DepartmentListViewModel, GetAllDepartmentQueryResponse>().ReverseMap();
        }
    }
}
