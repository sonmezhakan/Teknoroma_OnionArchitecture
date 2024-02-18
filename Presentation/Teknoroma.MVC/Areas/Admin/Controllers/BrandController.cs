using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Teknoroma.Application.Features.Brands.Command.Create;
using Teknoroma.Application.Features.Brands.Command.Update;
using Teknoroma.Application.Features.Brands.Models;
using Teknoroma.Application.Features.Brands.Quries.GetById;
using Teknoroma.Application.Features.Brands.Quries.GetList;
using Teknoroma.Infrastructure.WebApiService;
using Teknoroma.MVC.Models;

namespace Teknoroma.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize]
	public class BrandController : Controller
	{
		private readonly IMapper _mapper;
		private readonly IApiService _apiService;

		public BrandController(IMapper mapper, IApiService apiService)
        {
			_mapper = mapper;
			_apiService = apiService;
		}
		[HttpGet]
        public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateBrandViewModel model)
		{
			if(ModelState.IsValid)
			{
                CreateBrandCommandRequest createBrand= _mapper.Map<CreateBrandCommandRequest>(model);

                HttpResponseMessage response = await _apiService.HttpClient.PostAsJsonAsync("brand/create", createBrand);

				if (!response.IsSuccessStatusCode)
				{
					await ErrorResponseViewModel.Instance.CopyForm(response);

					ModelState.AddModelError(ErrorResponseViewModel.Instance.Title, ErrorResponseViewModel.Instance.Detail);

					return View(model);
				}

				return RedirectToAction("Create", "Brand");
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
			await BrandViewBag();

            if (id == null) return View();

            var response = await _apiService.HttpClient.GetFromJsonAsync<GetByIdBrandQueryResponse>($"brand/getbyid/{id}");

			BrandViewModel brandViewModel = _mapper.Map<BrandViewModel>(response);

            return View(brandViewModel);
		}

		[HttpPost]
		public async Task<IActionResult> Update(BrandViewModel model)
		{
			if(ModelState.IsValid)
			{
                UpdateBrandCommandRequest updateBrand = _mapper.Map<UpdateBrandCommandRequest>(model);

				HttpResponseMessage response = await _apiService.HttpClient.PutAsJsonAsync("brand/update", updateBrand);

				if (!response.IsSuccessStatusCode)
				{
					await ErrorResponseViewModel.Instance.CopyForm(response);

					ModelState.AddModelError(ErrorResponseViewModel.Instance.Title, ErrorResponseViewModel.Instance.Detail);

					await BrandViewBag();

					return View(model);
				}

				return RedirectToAction("Update", model.ID);
			}
			else
			{
				ModelState.AddModelError(string.Empty, "Hatalı İşlem!");

				await BrandViewBag();

				return View(model);
			}
		}

        [HttpGet]
		public async Task<IActionResult> Delete(Guid id)
		{
			await _apiService.HttpClient.DeleteAsync($"brand/delete/{id}");

			return RedirectToAction("BrandList", "Brand");
        }

		[HttpGet]
		public async Task<IActionResult> Detail(Guid? id)
		{
			await BrandViewBag();

			if (id == null) return View();

            var response = await _apiService.HttpClient.GetFromJsonAsync<GetByIdBrandQueryResponse>($"brand/getbyid/{id}");

			BrandViewModel brandViewModel = _mapper.Map<BrandViewModel>(response);

			return View(brandViewModel);

		}

		[HttpGet]
		public async Task<IActionResult> BrandList()
		{
			var response = await _apiService.HttpClient.GetFromJsonAsync<List<GetAllBrandCommandResponse>>("brand/getall");

			if (response == null) return View();

			List<BrandViewModel> brandViewModels = _mapper.Map<List<BrandViewModel>>(response);

			return View(brandViewModels);
		}

        public async Task BrandViewBag()
        {
            var getBrandList = _apiService.HttpClient.GetFromJsonAsync<List<GetAllBrandCommandResponse>>("brand/getall").Result.Select(x => new GetAllBrandCommandResponse
			{
				BrandName = x.BrandName,
				ID = x.ID
			}).ToList();

			ViewBag.BrandList = getBrandList;
		}
    }
}
