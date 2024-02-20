﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Suppliers.Command.Create;
using Teknoroma.Application.Features.Suppliers.Command.Delete;
using Teknoroma.Application.Features.Suppliers.Command.Update;
using Teknoroma.Application.Features.Suppliers.Queries.GetById;
using Teknoroma.Application.Features.Suppliers.Queries.GetList;

namespace Teknoroma.WebApi.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class SupplierController : BaseController
	{
		[HttpPost]
		public async Task<IActionResult> Create(CreateSupplierCommandRequest createSupplierCommandRequest)
		{
			var result = await Mediator.Send(createSupplierCommandRequest);

			return Ok(result);
		}
		[HttpPut]
		public async Task<IActionResult> Update(UpdateSupplierCommandRequest updateSupplierCommandRequest)
		{
			var result = await Mediator.Send(updateSupplierCommandRequest);

			return Ok(result);
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var result = await Mediator.Send(new DeleteSupplierCommandRequest { ID = id });

			return Ok(result);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id)
		{
			var result = await Mediator.Send(new GetByIdSupplierQueryRequest { ID = id });

			return Ok(result);
		}
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var result = await Mediator.Send(new GetAllSupplierQueryRequest());

			return Ok(result);
		}
	}
}