using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Customers.Command.Create;
using Teknoroma.Application.Features.Customers.Command.Update;
using Teknoroma.Application.Features.Customers.Models;
using Teknoroma.Application.Features.Customers.Queries.GetById;
using Teknoroma.Application.Features.Customers.Queries.GetList;
using Teknoroma.MVC.Models;

namespace Teknoroma.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CustomerController : BaseController
    {

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
                CreateCustomerCommandRequest createCustomer = Mapper.Map<CreateCustomerCommandRequest>(model);

                HttpResponseMessage response = await ApiService.HttpClient.PostAsJsonAsync("customer/create", createCustomer);

				if (response.IsSuccessStatusCode) return RedirectToAction("Create" , "Customer");

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
            await CustomerViewBag();

            if (id == null) return View();

            var response = await ApiService.HttpClient.GetFromJsonAsync<GetByIdCustomerQueryResponse>($"customer/getbyid/{id}");
    
            CustomerViewModel customerViewModel = Mapper.Map<CustomerViewModel>(response);

            return View(customerViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CustomerViewModel model)
        {
            if(ModelState.IsValid)
            {
                UpdateCustomerCommandRequest updateCustomer = Mapper.Map<UpdateCustomerCommandRequest>(model);

                HttpResponseMessage response = await ApiService.HttpClient.PutAsJsonAsync("customer/update", updateCustomer);

				if (!response.IsSuccessStatusCode)
				{
					await ErrorResponseViewModel.Instance.CopyForm(response);

					ModelState.AddModelError(ErrorResponseViewModel.Instance.Title, ErrorResponseViewModel.Instance.Detail);

					await CustomerViewBag();

					return View(model);
				}

				return RedirectToAction("Update",model.ID);
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
             await ApiService.HttpClient.DeleteAsync($"customer/delete/{id}");

            return RedirectToAction("CustomerList", "Customer");
        }

        [HttpGet]
        public async Task<IActionResult> Detail(Guid? id)
        {
            await CustomerViewBag();

            if(id == null) return View();

            var response = await ApiService.HttpClient.GetFromJsonAsync<GetByIdCustomerQueryResponse>($"customer/getbyid/{id}");

            if(response == null) return View();

            CustomerViewModel  customerViewModel = Mapper.Map<CustomerViewModel>(response);

            return View(customerViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> CustomerList()
        {
            var response = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllCustomerQueryResponse>>("customer/getall");

            if(response == null) return View();

            List<CustomerViewModel> customerViewModels = Mapper.Map<List<CustomerViewModel>>(response);

            return View(customerViewModels);
        }

        private async Task CustomerViewBag()
        {
            var response = ApiService.HttpClient.GetFromJsonAsync<List<GetAllCustomerQueryResponse>>("customer/getall").Result.Select(x => new GetAllCustomerQueryResponse { ID = x.ID, FullName = x.FullName });

                ViewBag.CustomerList = response;
        }
    }
}
