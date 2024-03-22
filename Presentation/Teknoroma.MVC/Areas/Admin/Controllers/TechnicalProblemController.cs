using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Teknoroma.Application.Features.AppUsers.Queries.GetByUserName;
using Teknoroma.Application.Features.Employees.Queries.GetById;
using Teknoroma.Application.Features.TechnicalProblems.Commands.Create;
using Teknoroma.Application.Features.TechnicalProblems.Commands.Update;
using Teknoroma.Application.Features.TechnicalProblems.Models;
using Teknoroma.Application.Features.TechnicalProblems.Queries.GetById;
using Teknoroma.Application.Features.TechnicalProblems.Queries.GetList;
using Teknoroma.Domain.Enums;

namespace Teknoroma.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TechnicalProblemController : BaseController
    {
        [HttpGet]
		[Authorize(Roles = "Teknik Problem Bildir")]
		public async Task<IActionResult> TechnicalProblemReport()
        {
            return View();
        }

        [HttpPost]
		[Authorize(Roles = "Teknik Problem Bildir")]
		public async Task<IActionResult> TechnicalProblemReport(CreateTechnicalProblemViewModel model)
        {
            await CheckJwtBearer();
            if (!ModelState.IsValid)
				return View(model);

			CreateTechnicalProblemCommandRequest createTechnicalProblemCommandRequest = Mapper.Map<CreateTechnicalProblemCommandRequest>(model);

            createTechnicalProblemCommandRequest.BranchId = await CheckBranchId();
			createTechnicalProblemCommandRequest.EmployeeId = await CheckAppUser();
			createTechnicalProblemCommandRequest.TechnicalProblemStatu = TechnicalProblemStatu.TechnicalProblem;
            createTechnicalProblemCommandRequest.NotificationDate = DateTime.Now;


			HttpResponseMessage response = await ApiService.HttpClient.PostAsJsonAsync("technicalproblem/create", createTechnicalProblemCommandRequest);

            if(!response.IsSuccessStatusCode)
            {
                await HandleErrorResponse(response);
                return View(model);
            }

            return View();
        }
        [HttpGet]
		[Authorize(Roles = "Teknik Problem Güncelle")]
		public async Task<IActionResult> Update(Guid id)
        {
            await CheckJwtBearer();
            var getTechnicalProblemDetail = await GetById(id);

			if (getTechnicalProblemDetail == null) return RedirectToAction("TechnicalProblemList", "TechnicalProblem");

            TechnicalProblemViewModel technicalProblemViewModel = Mapper.Map<TechnicalProblemViewModel>(getTechnicalProblemDetail);

            return View(technicalProblemViewModel);
        }

        [HttpPost]
		[Authorize(Roles = "Teknik Problem Güncelle")]
		public async Task<IActionResult> Update(TechnicalProblemViewModel model)
        {
            await CheckJwtBearer();
            if (!ModelState.IsValid)
				return View(model);

			UpdateTechnicalProblemCommandRequest updateTechnicalProblemCommandRequest = Mapper.Map<UpdateTechnicalProblemCommandRequest>(model);

			HttpResponseMessage response = await ApiService.HttpClient.PutAsJsonAsync("technicalproblem/update", updateTechnicalProblemCommandRequest);

            if (!response.IsSuccessStatusCode)
            {
                await HandleErrorResponse(response);
                return View(model);
            }

            return RedirectToAction("Update","TechnicalProblem",  new { id= model.ID });
        }

        [HttpGet]
		[Authorize(Roles = "Teknik Problem Listele")]
		public async Task<IActionResult> TechnicalProblemList()
        {
            await CheckJwtBearer();
            var response = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllTechnicalProblemQueryResponse>>("technicalproblem/getall");

            if (response == null) return View();

            List<TechnicalProblemViewModel> technicalProblemListViewModels = Mapper.Map<List<TechnicalProblemViewModel>>(response);

            return View(technicalProblemListViewModels);
        }

        [HttpGet]
		[Authorize(Roles = "Teknik Problem Detayları")]
		public async Task<IActionResult> Detail(Guid id)
        {
            await CheckJwtBearer();
            var getTechnicalProblemDetail = await GetById(id);

			if (getTechnicalProblemDetail == null) return RedirectToAction("TechnicalProblemList", "TechnicalProblem");

			TechnicalProblemViewModel technicalProblemViewModel = Mapper.Map<TechnicalProblemViewModel>(getTechnicalProblemDetail);

			return View(technicalProblemViewModel);
		}

        [HttpGet]
		[Authorize(Roles = "Teknik Problem Güncelle")]
		public async Task<IActionResult> UpdateTechnicalStatu(Guid id, TechnicalProblemStatu technicalProblemStatu)
        {
            await CheckJwtBearer();
            var getTechnicalProblem = await GetById(id);

            if(getTechnicalProblem == null) return RedirectToAction("TechnicalProblemList", "TechnicalProblem");

            getTechnicalProblem.TechnicalProblemStatu = technicalProblemStatu;

            await ApiService.HttpClient.PutAsJsonAsync("technicalproblem/update", getTechnicalProblem);

            return RedirectToAction("TechnicalProblemList", "TechnicalProblem");
        }

        [HttpGet]
		[Authorize(Roles = "Teknik Problem Sil")]
		public async Task<IActionResult> Delete(Guid id)
        {
            await CheckJwtBearer();
            await ApiService.HttpClient.DeleteAsync($"technicalproblem/delete/{id}");

            return RedirectToAction("TechnicalProblemList", "TechnicalProblem");
        }

        private async Task<GetByIdTechnicalProblemQueryResponse> GetById(Guid id)
        {
            var getTechnicalProblem = await ApiService.HttpClient.GetFromJsonAsync<GetByIdTechnicalProblemQueryResponse>($"technicalproblem/getbyid/{id}");

            return getTechnicalProblem;
        }

		private async Task<Guid> CheckBranchId()
        {
			Guid getAppUserID = await CheckAppUser();

			var getEmployeeBranch = await ApiService.HttpClient.GetFromJsonAsync<GetByIdEmployeeQueryResponse>($"employee/getbyid/{getAppUserID}");

            return getEmployeeBranch.BranchID;
		}
        private async Task<Guid> CheckAppUser()
        {
            Guid getAppUserID = ApiService.HttpClient.GetFromJsonAsync<GetByUserNameAppUserQueryResponse>($"user/GetByUserName/{User.Identity.Name}").Result.ID;

            return getAppUserID;
        }
    }
}
