﻿using MediatR;
using Teknoroma.Application.Services.Suppliers;

namespace Teknoroma.Application.Features.Suppliers.Queries.GetSupplyReport
{
	public class GetSupplierSupplyReportQueryHandler : IRequestHandler<GetSupplierSupplyReportQueryRequest, List<GetSupplierSupplyReportQueryResponse>>
	{
		private readonly ISupplierService _supplierService;

		public GetSupplierSupplyReportQueryHandler(ISupplierService supplierService)
        {
			_supplierService = supplierService;
		}
        public async Task<List<GetSupplierSupplyReportQueryResponse>> Handle(GetSupplierSupplyReportQueryRequest request, CancellationToken cancellationToken)
		{
			var suppliers = await _supplierService.GetAllAsync();

			var bestSupplyReports = suppliers.GroupBy(x => x.ID)
				.Select(grouped => new
				{
					SupplierId = grouped.Key,
					CompanyName = grouped.Select(supplier => supplier.CompanyName).First(),
					TotalSupply = grouped.SelectMany(stockInputs => stockInputs.StockInputs.Where(x => x.IsActive == true &&
					x.StockEntryDate >= request.StartDate && x.StockEntryDate <= request.EndDate)
					.Select(stockInput => stockInput.Quantity)).Sum()
				}).OrderByDescending(x=>x.TotalSupply).ToList();

			return new List<GetSupplierSupplyReportQueryResponse>(bestSupplyReports.Select(x => new GetSupplierSupplyReportQueryResponse
			{
				SupplierId = x.SupplierId,
				CompanyName = x.CompanyName,
				TotalSupply = x.TotalSupply
			})).ToList();
		}
	}
}
