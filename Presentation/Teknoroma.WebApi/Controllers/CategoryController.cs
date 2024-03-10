using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Categories.Commands.Create;
using Teknoroma.Application.Features.Categories.Commands.Delete;
using Teknoroma.Application.Features.Categories.Commands.Update;
using Teknoroma.Application.Features.Categories.Dtos;
using Teknoroma.Application.Features.Categories.Queries.GetById;
using Teknoroma.Application.Features.Categories.Queries.GetCategoryEarningReport;
using Teknoroma.Application.Features.Categories.Queries.GetCategorySellingReport;
using Teknoroma.Application.Features.Categories.Queries.GetCategorySupplyReport;
using Teknoroma.Application.Features.Categories.Queries.GetList;

namespace Teknoroma.WebApi.Controllers
{

	[Route("api/[controller]/[action]")]
    [ApiController]

    public class CategoryController : BaseController
    {
		private readonly IMapper _mapper;

		public CategoryController(IMapper mapper)
        {
			_mapper = mapper;
		}
        [HttpPost]
		[Authorize(AuthenticationSchemes = "Bearer")]
		public async Task<IActionResult> Create([FromBody]CreateCategoryCommandRequest createCategoryCommandRequest)
        {
            var result = await Mediator.Send(createCategoryCommandRequest);

            return Ok(result);
        }
        [HttpPut]
		[Authorize(AuthenticationSchemes = "Bearer")]
		public async Task<IActionResult> Update([FromBody] UpdateCategoryCommandRequest updateCategoryCommandRequest)
        {
            var result = await Mediator.Send(updateCategoryCommandRequest);

            return Ok(result);
        }

        [HttpDelete("{id}")]
		[Authorize(AuthenticationSchemes = "Bearer")]
		public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await Mediator.Send(new DeleteCategoryCommandRequest { ID = id});

            return Ok(result);
        }
        [HttpGet("{id}")]
		[Authorize(AuthenticationSchemes = "Bearer")]
		public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await Mediator.Send(new GetByIdCategoryQueryRequest { ID = id });

            return Ok(result);
        }

        [HttpGet]
		[Authorize(AuthenticationSchemes = "Bearer")]
		public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetAllCategoryQueryRequest());

            return Ok(result);
        }

        [HttpGet("{startDate}/{endDate}")]
		[Authorize(AuthenticationSchemes = "Bearer")]
		public async Task<IActionResult> CategorySellingReport(string startDate,string endDate)
        {
            var result = await Mediator.Send(new GetCategorySellingReportQueryRequest { StartDate = DateTime.Parse(startDate), EndDate = DateTime.Parse(endDate) });

            return Ok(result);
        }

        [HttpGet("{startDate}/{endDate}")]
		[Authorize(AuthenticationSchemes = "Bearer")]
		public async Task<IActionResult> CategoryEarningReport(string startDate, string endDate)
        {
            var result = await Mediator.Send(new GetCategoryEarningReportQueryRequest { StartDate = DateTime.Parse(startDate), EndDate = DateTime.Parse(endDate) });

            return Ok(result);
        }

        [HttpGet("{startDate}/{endDate}")]
		[Authorize(AuthenticationSchemes = "Bearer")]
		public async Task<IActionResult> CategorySupplyReport(string startDate, string endDate)
        {
            var result = await Mediator.Send(new GetCategorySupplyReportQueryRequest { StartDate = DateTime.Parse(startDate), EndDate = DateTime.Parse(endDate) });

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> CategoryHomePageList()
        {
            var result = await Mediator.Send(new GetAllCategoryQueryRequest());

            if(result is GetAllCategoryQueryResponse)
            {
                List<CategoryHomePageListDto> categoryHomePageListDtos = _mapper.Map<List<CategoryHomePageListDto>>(result);

                return Ok(categoryHomePageListDtos);
            }
            return Ok(result);
        }
    }
    
}
