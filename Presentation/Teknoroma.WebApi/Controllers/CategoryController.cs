using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Categories.Commands.Create;
using Teknoroma.Application.Features.Categories.Commands.Delete;
using Teknoroma.Application.Features.Categories.Commands.Update;
using Teknoroma.Application.Features.Categories.Queries.GetById;
using Teknoroma.Application.Features.Categories.Queries.GetList;


namespace Teknoroma.WebApi.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    
    public class CategoryController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateCategoryCommandRequest createCategoryCommandRequest)
        {
            var result = await Mediator.Send(createCategoryCommandRequest);

            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommandRequest updateCategoryCommandRequest)
        {
            var result = await Mediator.Send(updateCategoryCommandRequest);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await Mediator.Send(new DeleteCategoryCommandRequest { ID = id});

            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await Mediator.Send(new GetByIdCategoryQueryRequest { ID = id });

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetAllCategoryQueryRequest());

            return Ok(result);
        }

    }
    
}
