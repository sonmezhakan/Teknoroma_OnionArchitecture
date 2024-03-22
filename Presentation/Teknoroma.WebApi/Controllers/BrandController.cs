using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Brands.Command.Create;
using Teknoroma.Application.Features.Brands.Command.Delete;
using Teknoroma.Application.Features.Brands.Command.Update;
using Teknoroma.Application.Features.Brands.Quries.GetBrandEarningReport;
using Teknoroma.Application.Features.Brands.Quries.GetBrandSellingReport;
using Teknoroma.Application.Features.Brands.Quries.GetById;
using Teknoroma.Application.Features.Brands.Quries.GetList;
using Teknoroma.Application.Features.Brands.Quries.GetListSelectIdAndName;

namespace Teknoroma.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class BrandController : BaseController
    {
        [HttpPost]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Marka Ekle")]
		public async Task<IActionResult> Create(CreateBrandCommandRequest createBrandCommandRequest)
        {
			var result = await Mediator.Send(createBrandCommandRequest);

			return Ok(result);
		}

        [HttpPut]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Marka Güncelle")]
		public async Task<IActionResult> Update(UpdateBrandCommandRequest updateBrandCommandRequest)
        {
			var result = await Mediator.Send(updateBrandCommandRequest);

			return Ok(result);
		}
        [HttpDelete("{id}")]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Marka Sil")]
		public async Task<IActionResult> Delete(Guid id)
        {
			var result = await Mediator.Send(new DeleteBrandCommandRequest { ID = id });

			return Ok(result);
		}
        
        [HttpGet("{id}")]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Marka Sorgula")]
		public async Task<IActionResult> GetById(Guid id)
        {
			var result = await Mediator.Send(new GetByIdBrandQueryRequest { ID = id });

			return Ok(result);
		}

        [HttpGet]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Marka Listele")]
		public async Task<IActionResult> GetAll()
        {
			var result = await Mediator.Send(new GetAllBrandCommandRequest());

			return Ok(result);
		}
        [HttpGet("{startDate}/{endDate}")]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Marka Raporları")]
		public async Task<IActionResult> BrandSellingReport(string startDate,string endDate)
        {
            var result = await Mediator.Send(new GetBrandSellingReportQueryRequest { StartDate = DateTime.Parse(startDate), EndDate = DateTime.Parse(endDate) });

            return Ok(result);
        }
        [HttpGet("{startDate}/{endDate}")]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Marka Raporları")]
		public async Task<IActionResult> BrandEarningReport(string startDate, string endDate)
        {
            var result = await Mediator.Send(new GetBrandEarningReportQueryRequest { StartDate = DateTime.Parse(startDate), EndDate = DateTime.Parse(endDate) });

            return Ok(result);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Marka Listele")]
        public async Task<IActionResult> GetAllSelectIdAndName()
        {
            var result = await Mediator.Send(new GetAllSelectIdAndNameBrandQueryRequest());

            return Ok(result);
        }
    }
}
