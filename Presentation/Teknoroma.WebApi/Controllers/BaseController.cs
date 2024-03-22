using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Teknoroma.WebApi.Controllers
{
    public class BaseController:ControllerBase
    {
		//protected olmasının nedeni bu classı sadece inherit edenlerin kullanması için

		private IMediator? _mediator;
        protected IMediator? Mediator => _mediator??= HttpContext.RequestServices.GetService<IMediator>();//Eğer _mediatr boş ise injectionu get et.
	}
}
