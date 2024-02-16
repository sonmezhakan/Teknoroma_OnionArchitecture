using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Brands.Command.Delete;
using Teknoroma.Application.Features.Products.Command.Create;
using Teknoroma.Application.Features.Products.Command.Delete;
using Teknoroma.Application.Features.Products.Command.Update;
using Teknoroma.Application.Features.Products.Queries.GetById;
using Teknoroma.Application.Features.Products.Queries.GetList;

namespace Teknoroma.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommandRequest createProductCommandRequest)
        {
			var result = await Mediator.Send(createProductCommandRequest);

			return Ok(result);
		}

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommandRequest updateProductCommandRequest)
        {
			var result = await Mediator.Send(updateProductCommandRequest);

			return Ok(result);
		}

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
			var result = await Mediator.Send(new DeleteProductCommandRequest { ID = id });

			return Ok(result);
		}

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetAllProductQueryRequest());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
			var result = await Mediator.Send(new GetByIdProductQueryRequest { ID = id });

			return Ok(result);
		}
    }
}
