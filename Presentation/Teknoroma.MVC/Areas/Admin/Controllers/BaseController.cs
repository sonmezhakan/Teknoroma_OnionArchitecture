using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Infrastructure.WebApiService;

namespace Teknoroma.MVC.Areas.Admin.Controllers
{
    public class BaseController:Controller
    {
        private IMapper? _mapper;
        protected IMapper? Mapper => _mapper ?? HttpContext.RequestServices.GetService<IMapper>();

        private IApiService? _apiService;
        protected IApiService? ApiService => _apiService ?? HttpContext.RequestServices.GetService<IApiService>();
    }
}
