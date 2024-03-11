using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Departments.Command.Create;
using Teknoroma.Application.Features.Departments.Command.Delete;
using Teknoroma.Application.Features.Departments.Command.Update;
using Teknoroma.Application.Features.Departments.Queries.GetById;
using Teknoroma.Application.Features.Departments.Queries.GetList;

namespace Teknoroma.WebApi.Controllers
{
	[Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Şube Müdürü,Muhasebe Temsilcisi")]
    public class DepartmentController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateDepartmentCommandRequest createDepartmentCommandRequest)
        {
			var result = await Mediator.Send(createDepartmentCommandRequest);

			return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateDepartmentCommandRequest updateDepartmentCommandRequest)
        {
			var result = await Mediator.Send(updateDepartmentCommandRequest);

			return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
			var result = await Mediator.Send(new DeleteDepartmentCommandRequest { ID = id });

			return Ok(result);
		}
       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
			var result = await Mediator.Send(new GetByIdDepartmentQueryRequest { ID = id });

			return Ok(result);
		}
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
			var result = await Mediator.Send(new GetAllDepartmentQueryRequest());

			return Ok(result);
		}
    }
}
