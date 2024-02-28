using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.AppUserRoles.Queries.GetList;
using Teknoroma.Application.Features.AppUsers.Queries.GetList;
using Teknoroma.Application.Features.Branches.Queries.GetAll;
using Teknoroma.Application.Features.Departments.Queries.GetList;
using Teknoroma.Application.Features.Employees.Command.Create;
using Teknoroma.Application.Features.Employees.Command.Update;
using Teknoroma.Application.Features.Employees.Models;
using Teknoroma.Application.Features.Employees.Queries.GetById;
using Teknoroma.Application.Features.Employees.Queries.GetEmployeeEarningReport;
using Teknoroma.Application.Features.Employees.Queries.GetEmployeeSellingReport;
using Teknoroma.Application.Features.Employees.Queries.GetList;
using Teknoroma.MVC.Models;

namespace Teknoroma.MVC.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class EmployeeController : BaseController
	{
		[HttpGet]
		public async Task<IActionResult> Create()
		{
			await ViewBagList();

            return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(CreateEmployeeViewModel model)
		{
            if (!ModelState.IsValid)
            {
                await ViewBagList();
                await ErrorResponse();
                return View(model);
            }

            CreateEmployeeCommandRequest createEmployeeCommandRequest = Mapper.Map<CreateEmployeeCommandRequest>(model);

            HttpResponseMessage response = await ApiService.HttpClient.PostAsJsonAsync("employee/create", createEmployeeCommandRequest);

            if (response.IsSuccessStatusCode) return View();

			await HandleErrorResponse(response);
            await ViewBagList();
            return View(model);
        }
		[HttpGet]
		public async Task<IActionResult> Update(Guid? id)
		{
            await ViewBagList();

            if (id == null) return View();

			var response = await GetByEmployeeId((Guid)id);

            UpdateEmployeeViewModel updateEmployeeViewModel = Mapper.Map<UpdateEmployeeViewModel>(response);

			return View(updateEmployeeViewModel);
		}
		[HttpPost]
		public async Task<IActionResult> Update(UpdateEmployeeViewModel model)
		{
            if (!ModelState.IsValid)
            {
                await ViewBagList();
                await ErrorResponse();
                return View(model);
            }
            UpdateEmployeeCommandRequest updateEmployeeCommandRequest = Mapper.Map<UpdateEmployeeCommandRequest>(model);

            HttpResponseMessage response = await ApiService.HttpClient.PutAsJsonAsync("employee/update", updateEmployeeCommandRequest);

            if (response.IsSuccessStatusCode) return RedirectToAction("Update", model.ID);

			await HandleErrorResponse(response);
            await ViewBagList();
            return View(model);

        }
		[HttpGet]
		public async Task<IActionResult> Delete(Guid id)
		{
			await ApiService.HttpClient.DeleteAsync($"employee/delete/{id}");

			return RedirectToAction("EmployeeList","Employee");
		}
		[HttpGet]
		public async Task<IActionResult> Detail(Guid? id)
		{
            await ViewBagList();

            if (id == null) return View();

			var response = await GetByEmployeeId((Guid)id);

            EmployeeViewModel employeeViewModel = Mapper.Map<EmployeeViewModel>(response);

			return View(employeeViewModel);
		}
		[HttpGet]
		public async Task<IActionResult> EmployeeList()
		{
			var response = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllEmployeeQueryResponse>>("employee/getall");

			List<EmployeeViewModel> employeeViewModel = Mapper.Map<List<EmployeeViewModel>>(response);

			return View(employeeViewModel);
		}

		[HttpGet]
		public async Task<IActionResult> EmployeeReport(DateTime? startDate,DateTime? endDate)
		{
            if (startDate == null || endDate == null)
            {
                startDate = DateTime.MinValue;
                endDate = DateTime.MaxValue;
            }
			var employeeSellingReports = await ApiService.HttpClient.GetFromJsonAsync<List<GetEmployeeSellingReportQueryResponse>>($"employee/EmployeeSellingReport/{startDate?.ToString("yyyy-MM-dd")}/{endDate?.ToString("yyyy-MM-dd")}");

			List<EmployeeSellingReportViewModel> employeeSellingReportViewModels = Mapper.Map<List<EmployeeSellingReportViewModel>>(employeeSellingReports);

			var employeeEarningReports = await ApiService.HttpClient.GetFromJsonAsync<List<GetEmployeeEarningReportQueryResponse>>($"employee/EmployeeEarningReport/{startDate?.ToString("yyyy-MM-dd")}/{endDate?.ToString("yyyy-MM-dd")}");

			List<EmployeeEarningReportViewModel> employeeEarningReportViewModels = Mapper.Map<List<EmployeeEarningReportViewModel>>(employeeEarningReports);


			EmployeeReportViewModel employeeReportViewModel = new EmployeeReportViewModel
			{
				EmployeeSellingReportViewModels = employeeSellingReportViewModels,
				EmployeeEarningReportViewModels = employeeEarningReportViewModels
			};
			return View(employeeReportViewModel);
		}

		private async Task<GetByIdEmployeeQueryResponse> GetByEmployeeId(Guid id)
		{
          return await ApiService.HttpClient.GetFromJsonAsync<GetByIdEmployeeQueryResponse>($"employee/getbyid/{id}");
        }
		private async Task ViewBagList()
		{
            await AppUserViewBag();
            await BranchViewBag();
            await DepartmentViewBag();
        }
		private async Task AppUserViewBag()
		{
			var appUser = ApiService.HttpClient.GetFromJsonAsync<List<GetAllAppUserQueryResponse>>("user/getall").Result
				.Select(x => new GetAllAppUserQueryResponse
				{
					ID = x.ID,
					UserName = x.UserName
				});

			ViewBag.AppUserList = appUser;
		}
		private async Task BranchViewBag()
		{
			var branches = ApiService.HttpClient.GetFromJsonAsync<List<GetAllBranchQueryResponse>>("branch/getall").Result
				.Select(x => new GetAllBranchQueryResponse
				{
					ID = x.ID,
					BranchName = x.BranchName
				});

			ViewBag.BranchList = branches;
		}
		private async Task DepartmentViewBag()
		{
			var departments = ApiService.HttpClient.GetFromJsonAsync<List<GetAllDepartmentQueryResponse>>("department/getall").Result
				.Select(x=> new GetAllDepartmentQueryResponse 
				{ 
					ID = x.ID, 
					DepartmentName = x.DepartmentName 
				});

			ViewBag.DepartmentList = departments;
		}
	}
}
