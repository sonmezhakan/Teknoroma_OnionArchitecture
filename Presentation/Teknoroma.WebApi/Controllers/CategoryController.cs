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
using Teknoroma.Application.Features.Categories.Queries.GetListSelectIdAndName;

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
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Kategori Ekle")]
		public async Task<IActionResult> Create([FromBody]CreateCategoryCommandRequest createCategoryCommandRequest)
        {
            var result = await Mediator.Send(createCategoryCommandRequest);

            return Ok(result);
        }
        [HttpPut]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Kategori Güncelle")]
		public async Task<IActionResult> Update([FromBody] UpdateCategoryCommandRequest updateCategoryCommandRequest)
        {
            var result = await Mediator.Send(updateCategoryCommandRequest);

            return Ok(result);
        }

        [HttpDelete("{id}")]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Kategori Sil")]
		public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await Mediator.Send(new DeleteCategoryCommandRequest { ID = id});

            return Ok(result);
        }
        [HttpGet("{id}")]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Kategori Sorgula")]
		public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await Mediator.Send(new GetByIdCategoryQueryRequest { ID = id });

            return Ok(result);
        }

        [HttpGet]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Kategori Listele")]
		public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetAllCategoryQueryRequest());

            return Ok(result);
        }
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Kategori Listele")]
        public async Task<IActionResult> GetAllSelectIdAndName()
        {
            var result = await Mediator.Send(new GetAllSelectIdAndNameCategoryQueryRequest());

            return Ok(result);
        }

        [HttpGet("{startDate}/{endDate}")]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Kategori Raporları")]
		public async Task<IActionResult> CategorySellingReport(string startDate,string endDate)
        {
            var result = await Mediator.Send(new GetCategorySellingReportQueryRequest { StartDate = DateTime.Parse(startDate), EndDate = DateTime.Parse(endDate) });

            return Ok(result);
        }

        [HttpGet("{startDate}/{endDate}")]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Kategori Raporları")]
		public async Task<IActionResult> CategoryEarningReport(string startDate, string endDate)
        {
            var result = await Mediator.Send(new GetCategoryEarningReportQueryRequest { StartDate = DateTime.Parse(startDate), EndDate = DateTime.Parse(endDate) });

            return Ok(result);
        }

        [HttpGet("{startDate}/{endDate}")]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Kategori Raporları")]
		public async Task<IActionResult> CategorySupplyReport(string startDate, string endDate)
        {
            var result = await Mediator.Send(new GetCategorySupplyReportQueryRequest { StartDate = DateTime.Parse(startDate), EndDate = DateTime.Parse(endDate) });

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> CategoryHomePageList()
        {
            var result = await Mediator.Send(new GetAllCategoryQueryRequest());

            if(result is List<GetAllCategoryQueryResponse>)
            {
                List<CategoryHomePageListDto> categoryHomePageListDtos = _mapper.Map<List<CategoryHomePageListDto>>(result.ToList());

                return Ok(categoryHomePageListDtos);
            }
            return Ok(result);
        }
    }
    
}
