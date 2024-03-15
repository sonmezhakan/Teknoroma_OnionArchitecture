using AutoMapper;
using Teknoroma.Application.Features.Expenses.Commands.Create;
using Teknoroma.Application.Features.Expenses.Commands.Update;
using Teknoroma.Application.Features.Expenses.Models;
using Teknoroma.Application.Features.Expenses.Queries.GetById;
using Teknoroma.Application.Features.Expenses.Queries.GetExpenseDetailReport;
using Teknoroma.Application.Features.Expenses.Queries.GetList;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Expenses.Profiles
{
	public class MapperProfile:Profile
	{
        public MapperProfile()
        {
            CreateMap<Expense, CreateExpenseCommandRequest>().ReverseMap();
            CreateMap<Expense,  UpdateExpenseCommandRequest>().ReverseMap();
            CreateMap<Expense, GetByIdExpenseQueryResponse>().ReverseMap();
            CreateMap<Expense, GetAllExpenseQueryResponse>()
				.ForMember(dest => dest.AppUserName, opt => opt.MapFrom(src => src.Employee.AppUser.UserName))
				.ReverseMap();

            CreateMap<CreateExpenseViewModel, CreateExpenseCommandRequest>().ReverseMap();
            CreateMap<ExpenseViewModel, UpdateExpenseCommandRequest>().ReverseMap();
            CreateMap<ExpenseViewModel , GetByIdExpenseQueryResponse>().ReverseMap();
            CreateMap<ExpenseListViewModel, GetAllExpenseQueryResponse>().ReverseMap();

            CreateMap<ExpenseDetailReportViewModel, GetExpenseDetailReportResponse>().ReverseMap();
        }
    }
}
