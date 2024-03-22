using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Branches.Command.Create;
using Teknoroma.Application.Features.Branches.Command.Delete;
using Teknoroma.Application.Features.Branches.Command.Update;
using Teknoroma.Application.Features.Branches.Queries.GetAll;
using Teknoroma.Application.Features.Branches.Queries.GetBranchEarningReport;
using Teknoroma.Application.Features.Branches.Queries.GetBranchSellingReport;
using Teknoroma.Application.Features.Branches.Queries.GetById;
using Teknoroma.Application.Features.Branches.Queries.GetListSelectIdAndName;


namespace Teknoroma.WebApi.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	[Authorize(AuthenticationSchemes = "Bearer")]
	public class BranchController : BaseController
	{
		[HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Şube Ekle")]
        public async Task<IActionResult> Create(CreateBranchCommandRequest createBranchCommandRequest)
		{
			var result = await Mediator.Send(createBranchCommandRequest);

			return Ok(result);
		}

		[HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Şube Güncelle")]
        public async Task<IActionResult> Update(UpdateBranchCommandRequest updateBranchCommandRequest)
		{
			var result = await Mediator.Send(updateBranchCommandRequest);

			return Ok(result);
		}

		[HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Şube Sil")]
        public async Task<IActionResult> Delete(Guid id)
		{
			var result = await Mediator.Send(new DeleteBranchCommandRequest { ID = id});

			return Ok(result);
		}

		
		[HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Şube Sorgula")]
        public async Task<IActionResult> GetById(Guid id)
		{
			var result = await Mediator.Send(new GetByIdBranchQueryRequest { ID = id });

			return Ok(result);
		}
		[HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Şube Listele")]
        public async Task<IActionResult> GetAll()
		{
			var result = await Mediator.Send(new GetAllBranchQueryRequest());

			return Ok(result);
		}
		[HttpGet("{startDate}/{endDate}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Şube Raporları")]
        public async Task<IActionResult> BranchSellingReport(string startDate,string endDate)
		{
			var result = await Mediator.Send(new GetBranchSellingReportQueryRequest { StartDate = DateTime.Parse(startDate), EndDate = DateTime.Parse(endDate) });

			return Ok(result);
		}
        [HttpGet("{startDate}/{endDate}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Şube Raporları")]
        public async Task<IActionResult> BranchEarningReport(string startDate, string endDate)
        {
            var result = await Mediator.Send(new GetBranchEarningReportQueryRequest { StartDate = DateTime.Parse(startDate), EndDate = DateTime.Parse(endDate) });

            return Ok(result);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Şube Listele")]
        public async Task<IActionResult> GetAllSelectIdAndName()
        {
            var result = await Mediator.Send(new GetAllSelectIdAndNameBranchQueryRequest());

            return Ok(result);
        }
    }
}
