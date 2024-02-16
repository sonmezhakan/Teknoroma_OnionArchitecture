using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.BranchProducts.Queries.GetList;

namespace Teknoroma.WebApi.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class BranchProductController : BaseController
	{
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var result = await Mediator.Send(new GetAllBranchProductQueryRequest());

			return Ok(result);
		}
	}
}
