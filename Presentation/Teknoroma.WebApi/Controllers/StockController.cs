
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Stocks.Queries.GetList;
using Teknoroma.Application.Features.Stocks.Queries.GetStockTrackingReportList;

namespace Teknoroma.WebApi.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
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

		[HttpGet("{id}")]
		public async Task<IActionResult> StockTrackingReport(Guid id)
		{ 
			var result = await Mediator.Send(new GetStockTrackingReportListQueryRequest { BranchId = id });

			return Ok(result);
		}
	}
}
