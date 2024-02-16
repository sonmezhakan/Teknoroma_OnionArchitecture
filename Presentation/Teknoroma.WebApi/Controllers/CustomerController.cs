using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Branches.Queries.GetAll;
using Teknoroma.Application.Features.Customers.Command.Create;
using Teknoroma.Application.Features.Customers.Command.Delete;
using Teknoroma.Application.Features.Customers.Command.Update;
using Teknoroma.Application.Features.Customers.Queries.GetById;
using Teknoroma.Application.Features.Customers.Queries.GetList;


namespace Teknoroma.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerCommandRequest createCustomerCommandRequest)
        {
			var result = await Mediator.Send(createCustomerCommandRequest);

			return Ok(result);
		}

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCustomerCommandRequest updateCustomerCommandRequest)
        {
			var result = await Mediator.Send(updateCustomerCommandRequest);

			return Ok(result);
		}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
			var result = await Mediator.Send(new DeleteCustomerCommandRequest {ID = id });

			return Ok(result);
		}
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
			var result = await Mediator.Send(new GetByIdCustomerCommandRequest { ID = id });

			return Ok(result);
		}
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
			var result = await Mediator.Send(new GetAllCustomerCommandRequest());

			return Ok(result);
		}

    }
}
