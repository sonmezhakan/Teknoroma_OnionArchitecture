using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.AppUsers.Queries.GetByUserName;
using Teknoroma.Application.Features.Expenses.Commands.Create;
using Teknoroma.Application.Features.Expenses.Commands.Update;
using Teknoroma.Application.Features.Expenses.Models;
using Teknoroma.Application.Features.Expenses.Queries.GetById;
using Teknoroma.Application.Features.Expenses.Queries.GetExpenseDetailReport;
using Teknoroma.Application.Features.Expenses.Queries.GetList;

namespace Teknoroma.MVC.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class ExpenseController : BaseController
	{
		[HttpGet]
		[Authorize(Roles = "Gider Ekle")]
		public async Task<IActionResult> Create()
		{
			await CheckJwtBearer();
			return View();
		}

		[HttpPost]
		[Authorize(Roles = "Gider Ekle")]
		public async Task<IActionResult> Create(CreateExpenseViewModel model)
		{
			await CheckJwtBearer();

			if (!ModelState.IsValid)
				return View(model);

			CreateExpenseCommandRequest createExpenseCommandRequest = Mapper.Map<CreateExpenseCommandRequest>(model);
			createExpenseCommandRequest.EmployeeId = await CheckAppUser();

			HttpResponseMessage response =  await ApiService.HttpClient.PostAsJsonAsync("expense/create", createExpenseCommandRequest);

			if (!response.IsSuccessStatusCode)
			{
				await HandleErrorResponse(response);
				return View(model);
			}

			return RedirectToAction("Create","Expense");
		}

		[HttpGet]
		[Authorize(Roles = "Gider Güncelle")]
		public async Task<IActionResult> Update(Guid? id)
		{
			await CheckJwtBearer();

			if (id == null) return View();

			var expense = await GetById((Guid)id);

			ExpenseViewModel expenseViewModel = Mapper.Map<ExpenseViewModel>(expense);

			return View(expenseViewModel);
		}

		[HttpPost]
		[Authorize(Roles = "Gider Güncelle")]
		public async Task<IActionResult> Update(ExpenseViewModel model)
		{
			await CheckJwtBearer();

			if (!ModelState.IsValid)
				return View(model);

			UpdateExpenseCommandRequest updateExpenseCommandRequest = Mapper.Map<UpdateExpenseCommandRequest>(model);

			HttpResponseMessage response = await ApiService.HttpClient.PutAsJsonAsync("expense/update", updateExpenseCommandRequest);

			if(!response.IsSuccessStatusCode)
			{
				await HandleErrorResponse(response);
				return View(model);
			}

			return RedirectToAction("Update", "Expense" , new { id=model.ID});
		}

		[HttpGet]
		[Authorize(Roles = "Gider Sil")]
		public async Task<IActionResult> Delete(Guid id)
		{
			await CheckJwtBearer();

			await ApiService.HttpClient.DeleteAsync($"expense/delete/{id}");

			return RedirectToAction("ExpenseList", "Expense");
		}

		[HttpGet]
		[Authorize(Roles = "Gider Detayları")]
		public async Task<IActionResult> Detail(Guid? id)
		{
			await CheckJwtBearer();

			if (id == null) return View();

			var expense = await GetById((Guid)id);

			ExpenseViewModel expenseViewModel = Mapper.Map<ExpenseViewModel>(expense);

			return View(expenseViewModel);
		}

		[HttpGet]
		[Authorize(Roles = "Gider Listele")]
		public async Task<IActionResult> ExpenseList()
		{
			await CheckJwtBearer();

			var response = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllExpenseQueryResponse>>("expense/getall");

			if (response == null) return View();

			List<ExpenseListViewModel> expenseListViewModels = Mapper.Map<List<ExpenseListViewModel>>(response);

			return View(expenseListViewModels);
		}

		[HttpGet]
		[Authorize(Roles = "Gider Raporları")]
		public async Task<IActionResult> ExpenseReport(DateTime? startDate, DateTime? endDate)
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

			var response = await ApiService.HttpClient.GetFromJsonAsync<List<GetExpenseDetailReportResponse>>($"expense/ExpenseReport/{startDate?.ToString("yyyy-MM-dd")}/{endDate?.ToString("yyyy-MM-dd")}");

			if (response == null) return View();

			List<ExpenseDetailReportViewModel> expenseDetailReportViewModels = Mapper.Map<List<ExpenseDetailReportViewModel>>(response);

			return View(expenseDetailReportViewModels);
		}

		private async Task<GetByIdExpenseQueryResponse> GetById(Guid id)
		{
			var result = await ApiService.HttpClient.GetFromJsonAsync<GetByIdExpenseQueryResponse>($"expense/getbyid/{id}");

			return result;
		}
		private async Task<Guid> CheckAppUser()
		{
			Guid getAppUserID = ApiService.HttpClient.GetFromJsonAsync<GetByUserNameAppUserQueryResponse>($"user/GetByUserName/{User.Identity.Name}").Result.ID;

			return getAppUserID;
		}
	}
}
