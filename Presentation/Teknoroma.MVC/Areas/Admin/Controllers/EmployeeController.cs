using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.AppUsers.Queries.GetList;
using Teknoroma.Application.Features.AppUsers.Queries.GetListSelectIdAndName;
using Teknoroma.Application.Features.Branches.Queries.GetAll;
using Teknoroma.Application.Features.Branches.Queries.GetListSelectIdAndName;
using Teknoroma.Application.Features.Departments.Queries.GetList;
using Teknoroma.Application.Features.Departments.Queries.GetListSelectIdAndName;
using Teknoroma.Application.Features.Employees.Command.Create;
using Teknoroma.Application.Features.Employees.Command.Update;
using Teknoroma.Application.Features.Employees.Models;
using Teknoroma.Application.Features.Employees.Queries.GetById;
using Teknoroma.Application.Features.Employees.Queries.GetEmployeeDetailReport;
using Teknoroma.Application.Features.Employees.Queries.GetEmployeeEarningReport;
using Teknoroma.Application.Features.Employees.Queries.GetEmployeeSellingReport;
using Teknoroma.Application.Features.Employees.Queries.GetFullList;

namespace Teknoroma.MVC.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class EmployeeController : BaseController
	{
		[HttpGet]
		[Authorize(Roles = "Çalışan Ekle")]
		public async Task<IActionResult> Create()
		{
            await CheckJwtBearer();
            await ViewBagList();

            return View();
		}
		[HttpPost]
		[Authorize(Roles = "Çalışan Ekle")]
		public async Task<IActionResult> Create(CreateEmployeeViewModel model)
		{
            await CheckJwtBearer();
            if (!ModelState.IsValid)
            {
                await ViewBagList();
                 
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
		[Authorize(Roles = "Çalışan Güncelle")]
		public async Task<IActionResult> Update(Guid? id)
		{
            await CheckJwtBearer();
            await ViewBagList();

            if (id == null) return View();

			var response = await GetByEmployeeId((Guid)id);

            UpdateEmployeeViewModel updateEmployeeViewModel = Mapper.Map<UpdateEmployeeViewModel>(response);

			return View(updateEmployeeViewModel);
		}
		[HttpPost]
		[Authorize(Roles = "Çalışan Güncelle")]
		public async Task<IActionResult> Update(UpdateEmployeeViewModel model)
		{
            await CheckJwtBearer();
            if (!ModelState.IsValid)
            {
                await ViewBagList();
                 
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
		[Authorize(Roles = "Çalışan Sil")]
		public async Task<IActionResult> Delete(Guid id)
		{
            await CheckJwtBearer();
            await ApiService.HttpClient.DeleteAsync($"employee/delete/{id}");

			return RedirectToAction("EmployeeList","Employee");
		}
		[HttpGet]
		[Authorize(Roles = "Çalışan Detayları")]
		public async Task<IActionResult> Detail(Guid? id)
		{
            await CheckJwtBearer();
            await ViewBagList();

            if (id == null) return View();

			var response = await GetByEmployeeId((Guid)id);

            EmployeeViewModel employeeViewModel = Mapper.Map<EmployeeViewModel>(response);

			return View(employeeViewModel);
		}
		[HttpGet]
		[Authorize(Roles = "Çalışan Listele")]
		public async Task<IActionResult> EmployeeList()
		{
            await CheckJwtBearer();
            var response = await ApiService.HttpClient.GetFromJsonAsync<List<GetFullListEmployeeQueryResponse>>("employee/GetFullAll");

			List<EmployeeViewModel> employeeViewModel = Mapper.Map<List<EmployeeViewModel>>(response);

			return View(employeeViewModel);
		}

		[HttpGet]
		[Authorize(Roles = "Çalışan Raporları")]
		public async Task<IActionResult> EmployeeReport(DateTime? startDate,DateTime? endDate)
		{
            await CheckJwtBearer();
            if (startDate == null || endDate == null)
            {
                startDate = DateTime.MinValue;
                endDate = DateTime.MaxValue;
            }
            else
            {
                endDate = endDate.Value.AddDays(1);
            }
            var employeeSellingReports = await ApiService.HttpClient.GetFromJsonAsync<List<GetEmployeeSellingReportQueryResponse>>($"employee/EmployeeSellingReport/{startDate?.ToString("yyyy-MM-dd")}/{endDate?.ToString("yyyy-MM-dd")}");

			List<EmployeeSellingReportViewModel> employeeSellingReportViewModels = Mapper.Map<List<EmployeeSellingReportViewModel>>(employeeSellingReports);

			var employeeEarningReports = await ApiService.HttpClient.GetFromJsonAsync<List<GetEmployeeEarningReportQueryResponse>>($"employee/EmployeeEarningReport/{startDate?.ToString("yyyy-MM-dd")}/{endDate?.ToString("yyyy-MM-dd")}");

			List<EmployeeEarningReportViewModel> employeeEarningReportViewModels = Mapper.Map<List<EmployeeEarningReportViewModel>>(employeeEarningReports);

			var employeeDetailReports = await ApiService.HttpClient.GetFromJsonAsync<List<GetEmployeeDetailReportQueryResponse>>($"employee/EmployeeDetailReport/{startDate?.ToString("yyyy-MM-dd")}/{endDate?.ToString("yyyy-MM-dd")}");

			List<EmployeeDetailReportViewModel> employeeDetailReportViewModels = Mapper.Map<List<EmployeeDetailReportViewModel>>(employeeDetailReports);

			EmployeeReportViewModel employeeReportViewModel = new EmployeeReportViewModel
			{
				EmployeeSellingReportViewModels = employeeSellingReportViewModels,
				EmployeeEarningReportViewModels = employeeEarningReportViewModels,
				EmployeeDetailReportViewModels = employeeDetailReportViewModels
            };
			return View(employeeReportViewModel);
		}

		[HttpGet]
		public async Task<IActionResult> UpdateEmployeeActive(Guid id)
		{
			await CheckJwtBearer();
			var getEmployee = await GetByEmployeeId(id);

			UpdateEmployeeCommandRequest updateEmployeeCommandRequest = Mapper.Map<UpdateEmployeeCommandRequest>(getEmployee);
			updateEmployeeCommandRequest.IsActive = true;

			await ApiService.HttpClient.PutAsJsonAsync("employee/update", updateEmployeeCommandRequest);

			return RedirectToAction("EmployeeList", "Employee");
		}

		private async Task<GetByIdEmployeeQueryResponse> GetByEmployeeId(Guid id)
		{
          var result = await ApiService.HttpClient.GetFromJsonAsync<GetByIdEmployeeQueryResponse>($"employee/getbyid/{id}");

			return result;
        }
		private async Task ViewBagList()
		{
            await AppUserViewBag();
            await BranchViewBag();
            await DepartmentViewBag();
        }
		private async Task AppUserViewBag()
		{
			var appUser = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllSelectIdAndNameAppUserQueryResponse>>("user/GetAllSelectIdAndName");

			ViewBag.AppUserList = appUser;
		}
		private async Task BranchViewBag()
		{
			var branches = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllSelectIdAndNameBranchQueryResponse>>("branch/GetAllSelectIdAndName");

			ViewBag.BranchList = branches;
		}
		private async Task DepartmentViewBag()
		{
			var departments = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllSelectIdAndNameDepartmentResponse>>("department/GetAllSelectIdAndName");

			ViewBag.DepartmentList = departments;
		}
	}
}
