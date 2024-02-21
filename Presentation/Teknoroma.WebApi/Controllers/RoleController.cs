using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.AppUserRoles.Command.Create;
using Teknoroma.Application.Features.AppUserRoles.Command.Delete;
using Teknoroma.Application.Features.AppUserRoles.Command.Update;
using Teknoroma.Application.Features.AppUserRoles.Queries.GetById;
using Teknoroma.Application.Features.AppUserRoles.Queries.GetList;

namespace Teknoroma.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateAppUserRoleCommandRequest createAppUserRoleCommandRequest)
        {
            var result = await Mediator.Send(createAppUserRoleCommandRequest);

            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAppUserRoleCommandRequest updateAppUserRoleCommandRequest)
        {
            var result = await Mediator.Send(updateAppUserRoleCommandRequest);

            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await Mediator.Send(new DeleteAppUserRoleCommandRequest { ID = id });

            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await Mediator.Send(new GetByIdAppUserRoleQueryRequest { ID = id });

            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetAllAppUserRoleQueryRequest());

            return Ok(result);
        }
    }
}
