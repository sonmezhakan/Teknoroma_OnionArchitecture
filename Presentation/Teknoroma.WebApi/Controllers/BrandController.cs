using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Brands.Command.Create;
using Teknoroma.Application.Features.Brands.Command.Delete;
using Teknoroma.Application.Features.Brands.Command.Update;
using Teknoroma.Application.Features.Brands.Quries.GetById;
using Teknoroma.Application.Features.Brands.Quries.GetList;
using Teknoroma.Application.Features.Departments.Command.Delete;

namespace Teknoroma.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateBrandCommandRequest createBrandCommandRequest)
        {
			var result = await Mediator.Send(createBrandCommandRequest);

			return Ok(result);
		}

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBrandCommandRequest updateBrandCommandRequest)
        {
			var result = await Mediator.Send(updateBrandCommandRequest);

			return Ok(result);
		}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
			var result = await Mediator.Send(new DeleteBrandCommandRequest { ID = id });

			return Ok(result);
		}
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
			var result = await Mediator.Send(new GetByIdBrandCommandRequest { ID = id });

			return Ok(result);
		}

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
			var result = await Mediator.Send(new GetAllBrandCommandRequest());

			return Ok(result);
		}
    }
}
