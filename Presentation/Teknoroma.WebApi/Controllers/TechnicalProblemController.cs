using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.TechnicalProblems.Commands.Create;
using Teknoroma.Application.Features.TechnicalProblems.Commands.Delete;
using Teknoroma.Application.Features.TechnicalProblems.Commands.Update;
using Teknoroma.Application.Features.TechnicalProblems.Queries.GetById;
using Teknoroma.Application.Features.TechnicalProblems.Queries.GetList;

namespace Teknoroma.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class TechnicalProblemController : BaseController
    {
        [HttpPost]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Teknik Problem Bildir")]
		public async Task<IActionResult> Create(CreateTechnicalProblemCommandRequest createTechnicalProblemCommandRequest)
        {
            var result = await Mediator.Send(createTechnicalProblemCommandRequest);

            return Ok(result);
        }

        [HttpPut]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Teknik Problem Güncelle")]
		public async Task<IActionResult> Update(UpdateTechnicalProblemCommandRequest updateTechnicalProblemCommandRequest)
        {
            var result = await Mediator.Send(updateTechnicalProblemCommandRequest);

            return Ok(result);
        }

        [HttpDelete("{id}")]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Teknik Problem Sil")]
		public async Task<IActionResult> Delete(Guid id)
        {
            var result = await Mediator.Send(new DeleteTechnicalProblemCommandRequest { ID = id });

            return Ok(result);
        }

        [HttpGet("{id}")]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Teknik Problem Sorgula")]
		public async Task<IActionResult> GetById(Guid id)
        {
            var result = await Mediator.Send(new GetByIdTechnicalProblemQueryRequest { ID = id });

            return Ok(result);
        }

        [HttpGet]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Teknik Problem Listele")]
		public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetAllTechnicalProblemQueryRequest());

            return Ok(result);
        }
    }
}
