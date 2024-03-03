using AutoMapper;
using Teknoroma.Application.Features.Employees.Command.Create;
using Teknoroma.Application.Features.Employees.Command.Update;
using Teknoroma.Application.Features.Employees.Models;
using Teknoroma.Application.Features.Employees.Queries.GetById;
using Teknoroma.Application.Features.Employees.Queries.GetEmployeeDetailReport;
using Teknoroma.Application.Features.Employees.Queries.GetEmployeeEarningReport;
using Teknoroma.Application.Features.Employees.Queries.GetEmployeeSellingReport;
using Teknoroma.Application.Features.Employees.Queries.GetList;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Employees.Profiles
{
    public class MapperProfile:Profile
	{
        public MapperProfile()
        {
            CreateMap<Employee, CreateEmployeeCommandRequest>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeCommandRequest>().ReverseMap();

            CreateMap<CreateEmployeeViewModel, CreateEmployeeCommandRequest>().ReverseMap();
            CreateMap<UpdateEmployeeViewModel, UpdateEmployeeCommandRequest>().ReverseMap();

            CreateMap<UpdateEmployeeViewModel, GetByIdEmployeeQueryResponse>().ReverseMap();
            CreateMap<EmployeeViewModel, GetByIdEmployeeQueryResponse>().ReverseMap();
            CreateMap<EmployeeViewModel, GetAllEmployeeQueryResponse>().ReverseMap();

            CreateMap<Employee, GetByIdEmployeeQueryResponse>()
                .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch.BranchName))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DepartmentName))
                .ForMember(dest=> dest.UserName, opt=>opt.MapFrom(src=>src.AppUser.UserName))
                .ForMember(dest=>dest.Email, opt=>opt.MapFrom(src=>src.AppUser.Email))
                .ForMember(dest=>dest.PhoneNumber, opt=>opt.MapFrom(src=>src.AppUser.PhoneNumber))
                .ForMember(dest=>dest.FirstName, opt=>opt.MapFrom(src=>src.AppUser.AppUserProfile.FirstName))
                .ForMember(dest=>dest.LastName, opt=>opt.MapFrom(src=>src.AppUser.AppUserProfile.LastName))
                .ForMember(dest=>dest.Address, opt=>opt.MapFrom(src=>src.AppUser.AppUserProfile.Address))
                .ForMember(dest=>dest.NationalityNumber, opt=>opt.MapFrom(src=>src.AppUser.AppUserProfile.NationalityNumber))
                .ForMember(dest=>dest.Salary, opt=>opt.MapFrom(src=>src.Salary))
                .ReverseMap();

			CreateMap<Employee, GetAllEmployeeQueryResponse>()
				.ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch.BranchName))
				.ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DepartmentName))
				.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.AppUser.UserName))
				.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.AppUser.Email))
				.ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.AppUser.PhoneNumber))
				.ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.AppUser.AppUserProfile.FirstName))
				.ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.AppUser.AppUserProfile.LastName))
				.ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.AppUser.AppUserProfile.Address))
				.ForMember(dest => dest.NationalityNumber, opt => opt.MapFrom(src => src.AppUser.AppUserProfile.NationalityNumber))
				.ForMember(dest => dest.Salary, opt => opt.MapFrom(src => src.Salary))
				.ReverseMap();

            CreateMap<EmployeeSellingReportViewModel, GetEmployeeSellingReportQueryResponse>().ReverseMap();
            CreateMap<EmployeeEarningReportViewModel, GetEmployeeEarningReportQueryResponse>().ReverseMap();
            CreateMap<EmployeeDetailReportViewModel, GetEmployeeDetailReportQueryResponse>().ReverseMap();
            
		}
    }
}
