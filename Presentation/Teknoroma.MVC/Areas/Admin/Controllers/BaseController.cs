using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Teknoroma.Infrastructure.WebApiService;
using Teknoroma.MVC.Models;

namespace Teknoroma.MVC.Areas.Admin.Controllers
{
    public class BaseController:Controller
    {
        private IMapper? _mapper;
        protected IMapper? Mapper => _mapper ?? HttpContext.RequestServices.GetService<IMapper>();

        private IApiService? _apiService;
        protected IApiService? ApiService => _apiService ?? HttpContext.RequestServices.GetService<IApiService>();

        protected async Task HandleErrorResponse(HttpResponseMessage response)
        {
            await ErrorResponseViewModel.Instance.CopyForm(response);
            ModelState.AddModelError(ErrorResponseViewModel.Instance.Title, ErrorResponseViewModel.Instance.Detail);
        }

        protected async  Task ErrorResponse()
        {
            ModelState.AddModelError(string.Empty, "Hatalı İşlem!");
        }

        protected async Task CheckJwtBearer()
        {
                var token = Request.Cookies["LoginJWT"];
                ApiService.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);   
        }
    }
}
