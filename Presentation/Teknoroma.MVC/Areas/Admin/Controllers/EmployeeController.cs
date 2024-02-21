using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.AppUsers.Queries.GetList;
using Teknoroma.Application.Features.Branches.Queries.GetAll;
using Teknoroma.Application.Features.Departments.Queries.GetList;
using Teknoroma.Application.Features.Employees.Command.Create;
using Teknoroma.Application.Features.Employees.Command.Update;
using Teknoroma.Application.Features.Employees.Models;
using Teknoroma.Application.Features.Employees.Queries.GetById;
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
			await AppUserViewBag();
			await BranchViewBag();
			await DepartmentViewBag();

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(CreateEmployeeViewModel model)
		{
			await AppUserViewBag();
			await BranchViewBag();
			await DepartmentViewBag();

			if(ModelState.IsValid)
			{
				CreateEmployeeCommandRequest createEmployeeCommandRequest = Mapper.Map<CreateEmployeeCommandRequest>(model);

				HttpResponseMessage response = await ApiService.HttpClient.PostAsJsonAsync("employee/create", createEmployeeCommandRequest);

				if (response.IsSuccessStatusCode) return View();

				await ErrorResponseViewModel.Instance.CopyForm(response);

				ModelState.AddModelError(ErrorResponseViewModel.Instance.Title, ErrorResponseViewModel.Instance.Detail);

				return View(model);

			}
			else
			{
				ModelState.AddModelError(string.Empty, "Hatalı İşlem!");

				return View(model);
			}
		}
		[HttpGet]
		public async Task<IActionResult> Update(Guid? id)
		{
			await AppUserViewBag();
			await BranchViewBag();
			await DepartmentViewBag();

			if (id == null) return View();

			var response = await ApiService.HttpClient.GetFromJsonAsync<GetByIdEmployeeQueryResponse>($"employee/getbyid/{id}");

			GetByIdEmployeeQueryResponse getByIdEmployeeQueryResponse = Mapper.Map<GetByIdEmployeeQueryResponse>(response);

			return View(getByIdEmployeeQueryResponse);
		}
		[HttpPost]
		public async Task<IActionResult> Update(UpdateEmployeeViewModel model)
		{
			await AppUserViewBag();
			await BranchViewBag();
			await DepartmentViewBag();

			if(ModelState.IsValid)
			{
				UpdateEmployeeCommandRequest updateEmployeeCommandRequest = Mapper.Map<UpdateEmployeeCommandRequest>(model);

				HttpResponseMessage response = await ApiService.HttpClient.PutAsJsonAsync("employee/update", updateEmployeeCommandRequest);

				if (response.IsSuccessStatusCode) return View(model.ID);

				await ErrorResponseViewModel.Instance.CopyForm(response);

				ModelState.AddModelError(ErrorResponseViewModel.Instance.Title, ErrorResponseViewModel.Instance.Detail);

				return View(model);
			}
			else
			{
				ModelState.AddModelError(string.Empty, "Hatalı İşlem!");

				return View(model);
			}

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
			await AppUserViewBag();
			await BranchViewBag();
			await DepartmentViewBag();

			if (id == null) return View();

			var response = await ApiService.HttpClient.GetFromJsonAsync<GetByIdEmployeeQueryResponse>($"employee/getbyid/{id}");

			GetByIdEmployeeQueryResponse getByIdEmployeeQueryResponse = Mapper.Map<GetByIdEmployeeQueryResponse>(response);

			return View(getByIdEmployeeQueryResponse);
		}
		[HttpGet]
		public async Task<IActionResult> EmployeeList()
		{
			var response = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllEmployeeQueryResponse>>("employee/getall");

			EmployeeViewModel employeeViewModel = Mapper.Map<EmployeeViewModel>(response);

			return View(employeeViewModel);
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
