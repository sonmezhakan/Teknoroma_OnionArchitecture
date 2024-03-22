using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Teknoroma.Application.Services.WebApiServices;
using Teknoroma.MVC.Models;

namespace Teknoroma.MVC.Areas.Admin.Controllers
{
    public class BaseController:Controller
    {
        //protected olmasının nedeni bu classı sadece inherit edenlerin kullanması için

        private IMapper? _mapper;
        protected IMapper? Mapper => _mapper ?? HttpContext.RequestServices.GetService<IMapper>();//Eğer _mapper boş ise injectionu get et.

        private IApiService? _apiService;
        protected IApiService? ApiService => _apiService ?? HttpContext.RequestServices.GetService<IApiService>();//Eğer _apiService boş ise injectionu get et.


		//Global Exception tarafından gelen hata mesajları api tarafında json formatında gösterilmektedir. MVC tarafında ise geri dönen hataları daha iyi ve anlaşılır biçimde gösterebilmek için oluşturulan model üzerind deseriliza işlemi gerçekleştirilerek modele dönüştürüyor. Ayrıca ModelState hata mesajını ekleyerek ekranda gösterilmesi sağlanıyor.
		protected async Task HandleErrorResponse(HttpResponseMessage response)
        {
            await ErrorResponseViewModel.Instance.CopyForm(response);
            ModelState.AddModelError(ErrorResponseViewModel.Instance.Title, ErrorResponseViewModel.Instance.Detail);
        }

        //Authorization Schemasının Bearer olduğunu belirten metotu oluşturdum. Api tarafında Authorization ve yetkilere göre işlem yapıldığından bu metotun api isteğinden bulunacak metot tarafından çağırılması gerekmektedir.
        protected async Task CheckJwtBearer()
        {
                var token = Request.Cookies["LoginJWT"];
                ApiService.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);   
        }
    }
}
