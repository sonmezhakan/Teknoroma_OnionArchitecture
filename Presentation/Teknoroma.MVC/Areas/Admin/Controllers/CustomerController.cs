using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Customers.Command.Create;
using Teknoroma.Application.Features.Customers.Command.Update;
using Teknoroma.Application.Features.Customers.Models;
using Teknoroma.Application.Features.Customers.Queries.GetById;
using Teknoroma.Application.Features.Customers.Queries.GetList;
using Teknoroma.Infrastructure.WebApiService;

namespace Teknoroma.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IApiService _apiService;

        public CustomerController(IMapper mapper,IApiService apiService)
        {
           _mapper = mapper;
            _apiService = apiService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerViewModel model)
        {
            if(ModelState.IsValid)
            {
                CreateCustomerCommandRequest createCustomer = _mapper.Map<CreateCustomerCommandRequest>(model);

                HttpResponseMessage response = await _apiService.HttpClient.PostAsJsonAsync("customer/create", createCustomer);

                if (response.IsSuccessStatusCode) return View();

                ModelState.AddModelError(string.Empty, response.Content.ReadAsStringAsync().Result);

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
            await CustomerViewBag();

            if (id == null) return View();

            var response = await _apiService.HttpClient.GetFromJsonAsync<GetByIdCustomerCommandResponse>($"customer/getbyid/{id}");
    
            CustomerViewModel customerViewModel = _mapper.Map<CustomerViewModel>(response);

            return View(customerViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CustomerViewModel model)
        {
            if(ModelState.IsValid)
            {
                UpdateCustomerCommandRequest updateCustomer = _mapper.Map<UpdateCustomerCommandRequest>(model);

                HttpResponseMessage response = await _apiService.HttpClient.PutAsJsonAsync("customer/update", updateCustomer);

                if (response.IsSuccessStatusCode) return RedirectToAction("Update", new { id = model.ID });

                ModelState.AddModelError(string.Empty,response.Content.ReadAsStringAsync().Result);

                await CustomerViewBag();

                return View(model);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Hatalı İşlem!");

                await CustomerViewBag();

                return View(model);
            } 
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            HttpResponseMessage response = await _apiService.HttpClient.DeleteAsync($"customer/delete/{id}");

            if (response.IsSuccessStatusCode) return RedirectToAction("CustomerList", "Customer");

            ModelState.AddModelError(string.Empty, response.Content.ReadAsStringAsync().Result);

            return RedirectToAction("CustomerList", "Customer");
        }

        [HttpGet]
        public async Task<IActionResult> Detail(Guid? id)
        {
            await CustomerViewBag();

            if(id == null) return View();

            var response = await _apiService.HttpClient.GetFromJsonAsync<GetByIdCustomerCommandResponse>($"customer/getbyid/{id}");

            if(response == null) return View();

            CustomerViewModel  customerViewModel = _mapper.Map<CustomerViewModel>(response);

            return View(customerViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> CustomerList()
        {
            var response = await _apiService.HttpClient.GetFromJsonAsync<List<GetAllCustomerCommandResponse>>("customer/getall");

            if(response == null) return View();

            List<CustomerViewModel> customerViewModels = _mapper.Map<List<CustomerViewModel>>(response);

            return View(customerViewModels);
        }

        private async Task CustomerViewBag()
        {
            var response = _apiService.HttpClient.GetFromJsonAsync<List<GetAllCustomerCommandResponse>>("customer/getall").Result.Select(x => new GetAllCustomerCommandResponse { ID = x.ID, FullName = x.FullName }).ToList();

                ViewBag.CustomerList = response;
        }
    }
}
