﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.AppUsers.Command.Create;
using Teknoroma.Application.Features.AppUsers.Command.Update;
using Teknoroma.Application.Features.AppUsers.Commands.Login;
using Teknoroma.Application.Features.AppUsers.Queries.GetById;
using Teknoroma.Application.Features.AppUsers.Queries.GetByUserName;
using Teknoroma.Application.Features.AppUsers.Queries.GetList;
using Teknoroma.Application.Features.AppUsers.Queries.GetListSelectIdAndName;

namespace Teknoroma.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Login(LoginAppUserCommandRequest loginAppUserCommandRequest)
        {
            var result = await Mediator.Send(loginAppUserCommandRequest);

            return Ok(result);
        }

        [HttpGet("{userName}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Kullanıcı Sorgula")]
        public async Task<IActionResult> GetByUserName(string userName)
        {
            var result = await Mediator.Send(new GetByUserNameAppUserQueryRequest { UserName = userName });
            return Ok(result);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Kullanıcı Ekle")]
        public async Task<IActionResult> Create(CreateAppUserCommandRequest createAppUserCommandRequest)
        {
            var result = await Mediator.Send(createAppUserCommandRequest);

            return Ok(result);
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Update(UpdateAppUserCommandRequest updateAppUserCommandRequest)
        {
            var result = await Mediator.Send(updateAppUserCommandRequest);

            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Kullanıcı Sorgula")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await Mediator.Send(new GetByIdAppUserQueryRequest { ID = id });

            return Ok(result);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Kullanıcı Listele")]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetAllAppUserQueryRequest());

            return Ok(result);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Kullanıcı Listele")]
        public async Task<IActionResult> GetAllSelectIdAndName()
        {
            var result = await Mediator.Send(new GetAllSelectIdAndNameAppUserQueryRequest());

            return Ok(result);
        }

    }
}
