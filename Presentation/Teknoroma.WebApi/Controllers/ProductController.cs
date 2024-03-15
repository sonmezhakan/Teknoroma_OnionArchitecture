using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Products.Command.Create;
using Teknoroma.Application.Features.Products.Command.Delete;
using Teknoroma.Application.Features.Products.Command.Update;
using Teknoroma.Application.Features.Products.Dtos;
using Teknoroma.Application.Features.Products.Queries.GetByBarcodeCode;
using Teknoroma.Application.Features.Products.Queries.GetById;
using Teknoroma.Application.Features.Products.Queries.GetList;
using Teknoroma.Application.Features.Products.Queries.GetProductEarningReport;
using Teknoroma.Application.Features.Products.Queries.GetProductSalesDetailReport;
using Teknoroma.Application.Features.Products.Queries.GetProductSellingReport;
using Teknoroma.Application.Features.Products.Queries.GetProductSupplyDetailReport;
using Teknoroma.Application.Features.Products.Queries.GetProductSupplyReport;

namespace Teknoroma.WebApi.Controllers
{
	[Route("api/[controller]/[action]")]
    [ApiController]
    
    public class ProductController : BaseController
    {
		private readonly IMapper _mapper;

		public ProductController(IMapper mapper)
        {
			_mapper = mapper;
		}

        [HttpPost]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Şube Müdürü,Depo Temsilcisi")]
		public async Task<IActionResult> Create(CreateProductCommandRequest createProductCommandRequest)
        {
			var result = await Mediator.Send(createProductCommandRequest);

			return Ok(result);
		}

        [HttpPut]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Şube Müdürü,Depo Temsilcisi")]
		public async Task<IActionResult> Update(UpdateProductCommandRequest updateProductCommandRequest)
        {
			var result = await Mediator.Send(updateProductCommandRequest);

			return Ok(result);
		}

        [HttpDelete("{id}")]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Şube Müdürü,Depo Temsilcisi")]
		public async Task<IActionResult> Delete(Guid id)
        {
			var result = await Mediator.Send(new DeleteProductCommandRequest { ID = id });

			return Ok(result);
		}

        [HttpGet]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Şube Müdürü,Depo Temsilcisi")]
		public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetAllProductQueryRequest());

            return Ok(result);
        }

        [HttpGet("{id}")]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Şube Müdürü,Depo Temsilcisi,Satış Temsilcisi")]
		public async Task<IActionResult> GetById(Guid id)
        {
			var result = await Mediator.Send(new GetByIdProductQueryRequest { ID = id });

			return Ok(result);
		}

		[HttpGet("{startDate}/{endDate}")]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Şube Müdürü")]
		public async Task<IActionResult> ProductSellingReport(string startDate, string endDate)
		{
			var result = await Mediator.Send(new GetProductSellingReportQueryRequest { StartDate = DateTime.Parse(startDate), EndDate = DateTime.Parse(endDate) });

			return Ok(result);
		}
		[HttpGet("{startDate}/{endDate}")]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Şube Müdürü")]
		public async Task<IActionResult> ProductEarningReport(string startDate, string endDate)
		{
			var result = await Mediator.Send(new GetProductEarningReportQueryRequest { StartDate = DateTime.Parse(startDate), EndDate = DateTime.Parse(endDate) });

			return Ok(result);
		}
        [HttpGet("{startDate}/{endDate}")]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Şube Müdürü")]
		public async Task<IActionResult> ProductSupplyReport(string startDate, string endDate)
        {
            var result = await Mediator.Send(new GetProductSupplyReportQueryRequest { StartDate = DateTime.Parse(startDate), EndDate = DateTime.Parse(endDate) });

            return Ok(result);
        }
		[HttpGet("{startDate}/{endDate}")]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Şube Müdürü")]
		public async Task<IActionResult> ProductSalesDetailReport(string startDate, string endDate)
		{
			var result = await Mediator.Send(new GetProductSalesDetailReportQueryRequest {StartDate = DateTime.Parse(startDate), EndDate = DateTime.Parse(endDate) });

			return Ok(result);
		}
		[HttpGet("{startDate}/{endDate}")]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Şube Müdürü")]
		public async Task<IActionResult> ProductSupplyDetailReport(string startDate, string endDate)
		{
			var result = await Mediator.Send(new GetProductSupplyDetailReportQueryRequest {StartDate = DateTime.Parse(startDate), EndDate = DateTime.Parse(endDate) });

			return Ok(result);
		}
		[HttpGet("{barcodeCode}")]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Şube Müdürü")]
		public async Task<IActionResult> GetByBarcodeCode(string barcodeCode)
		{
			var result = await Mediator.Send(new GetByBarcodeCodeQueryRequest { BarcodeCode = barcodeCode });

			return Ok(result);
		}

		[HttpGet]
		public async Task<IActionResult> ProductHomePageList()
		{
			var result = await Mediator.Send(new GetAllProductQueryRequest());

			if(result is List<GetAllProductQueryResponse>)
			{
				List<ProductHomePageListDto> productHomePageListDto = _mapper.Map<List<ProductHomePageListDto>>(result.ToList());
				return Ok(productHomePageListDto);
			}

			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdProductPage(Guid id)
		{
			var result = await Mediator.Send(new GetByIdProductQueryRequest { ID = id });

			if(result is GetByIdProductQueryResponse)
			{
				ProductPageDto productPageDto = _mapper.Map<ProductPageDto>(result);
				return Ok(productPageDto);
			}

			return Ok(result);
		}
	}
}
