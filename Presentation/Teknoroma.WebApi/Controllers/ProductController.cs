using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Products.Command.Create;
using Teknoroma.Application.Features.Products.Command.Delete;
using Teknoroma.Application.Features.Products.Command.Update;
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
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ProductController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommandRequest createProductCommandRequest)
        {
			var result = await Mediator.Send(createProductCommandRequest);

			return Ok(result);
		}

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommandRequest updateProductCommandRequest)
        {
			var result = await Mediator.Send(updateProductCommandRequest);

			return Ok(result);
		}

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
			var result = await Mediator.Send(new DeleteProductCommandRequest { ID = id });

			return Ok(result);
		}

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetAllProductQueryRequest());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
			var result = await Mediator.Send(new GetByIdProductQueryRequest { ID = id });

			return Ok(result);
		}

		[HttpGet("{startDate}/{endDate}")]
		public async Task<IActionResult> ProductSellingReport(string startDate, string endDate)
		{
			var resut = await Mediator.Send(new GetProductSellingReportQueryRequest { StartDate = DateTime.Parse(startDate), EndDate = DateTime.Parse(endDate) });

			return Ok(resut);
		}
		[HttpGet("{startDate}/{endDate}")]
		public async Task<IActionResult> ProductEarningReport(string startDate, string endDate)
		{
			var resut = await Mediator.Send(new GetProductEarningReportQueryRequest { StartDate = DateTime.Parse(startDate), EndDate = DateTime.Parse(endDate) });

			return Ok(resut);
		}
        [HttpGet("{startDate}/{endDate}")]
        public async Task<IActionResult> ProductSupplyReport(string startDate, string endDate)
        {
            var resut = await Mediator.Send(new GetProductSupplyReportQueryRequest { StartDate = DateTime.Parse(startDate), EndDate = DateTime.Parse(endDate) });

            return Ok(resut);
        }
		[HttpGet("{startDate}/{endDate}")]
		public async Task<IActionResult> ProductSalesDetailReport(string startDate, string endDate)
		{
			var resut = await Mediator.Send(new GetProductSalesDetailReportQueryRequest {StartDate = DateTime.Parse(startDate), EndDate = DateTime.Parse(endDate) });

			return Ok(resut);
		}
		[HttpGet("{startDate}/{endDate}")]
		public async Task<IActionResult> ProductSupplyDetailReport(string startDate, string endDate)
		{
			var resut = await Mediator.Send(new GetProductSupplyDetailReportQueryRequest {StartDate = DateTime.Parse(startDate), EndDate = DateTime.Parse(endDate) });

			return Ok(resut);
		}
		[HttpGet("{barcodeCode}")]
		public async Task<IActionResult> GetByBarcodeCode(string barcodeCode)
		{
			var result = await Mediator.Send(new GetByBarcodeCodeQueryRequest { BarcodeCode = barcodeCode });

			return Ok(result);
		}
	}
}
