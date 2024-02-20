
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Stocks.Queries.GetList;

namespace Teknoroma.WebApi.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class StockController : BaseController
	{
		[HttpGet("{id}")]
		public async Task<IActionResult> GetAll(Guid? id)
		{
			if (id != null)
			{
                var result = await Mediator.Send(new GetAllStockQueryRequest { ID = id });
				return Ok(result);
            }
			else
			{
                var result = await Mediator.Send(new GetAllStockQueryRequest());

                return Ok(result);
            }            
		}
	}
}
