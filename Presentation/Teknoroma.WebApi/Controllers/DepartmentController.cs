using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Departments.Command.Create;
using Teknoroma.Application.Features.Departments.Command.Delete;
using Teknoroma.Application.Features.Departments.Command.Update;
using Teknoroma.Application.Features.Departments.Queries.GetById;
using Teknoroma.Application.Features.Departments.Queries.GetList;
using Teknoroma.Application.Features.Departments.Queries.GetListSelectIdAndName;

namespace Teknoroma.WebApi.Controllers
{
	[Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class DepartmentController : BaseController
    {
        [HttpPost]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Departman Ekle")]
		public async Task<IActionResult> Create(CreateDepartmentCommandRequest createDepartmentCommandRequest)
        {
			var result = await Mediator.Send(createDepartmentCommandRequest);

			return Ok(result);
        }
        [HttpPut]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Departman Güncelle")]
		public async Task<IActionResult> Update(UpdateDepartmentCommandRequest updateDepartmentCommandRequest)
        {
			var result = await Mediator.Send(updateDepartmentCommandRequest);

			return Ok(result);
        }
        [HttpDelete("{id}")]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Departman Sil")]
		public async Task<IActionResult> Delete(Guid id)
        {
			var result = await Mediator.Send(new DeleteDepartmentCommandRequest { ID = id });

			return Ok(result);
		}
       
        [HttpGet("{id}")]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Departman Sorgula")]
		public async Task<IActionResult> GetById(Guid id)
        {
			var result = await Mediator.Send(new GetByIdDepartmentQueryRequest { ID = id });

			return Ok(result);
		}
        [HttpGet]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Departman Listele")]
		public async Task<IActionResult> GetAll()
        {
			var result = await Mediator.Send(new GetAllDepartmentQueryRequest());

			return Ok(result);
		}
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Departman Listele")]
        public async Task<IActionResult> GetAllSelectIdAndName()
        {
            var result = await Mediator.Send(new GetAllSelectIdAndNameDepartmentRequest());

            return Ok(result);
        }
    }
}
