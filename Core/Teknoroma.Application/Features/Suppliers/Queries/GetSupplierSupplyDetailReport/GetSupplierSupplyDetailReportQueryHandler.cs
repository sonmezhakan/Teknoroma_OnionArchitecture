﻿using MediatR;
using Teknoroma.Application.Services.Repositories;

namespace Teknoroma.Application.Features.Suppliers.Queries.GetSupplierSupplyDetailReport
{
	public class GetSupplierSupplyDetailReportQueryHandler : IRequestHandler<GetSupplierSupplyDetailReportQueryRequest, List<GetSupplierSupplyDetailReportQueryResponse>>
	{
		private readonly ISupplierRepository _supplierRepository;

		public GetSupplierSupplyDetailReportQueryHandler(ISupplierRepository supplierRepository)
		{
			_supplierRepository = supplierRepository;
		}
		public async Task<List<GetSupplierSupplyDetailReportQueryResponse>> Handle(GetSupplierSupplyDetailReportQueryRequest request, CancellationToken cancellationToken)
		{
			var suppliers = await _supplierRepository.GetAllAsync();

			List<GetSupplierSupplyDetailReportQueryResponse> getSupplierSupplyDetailReportQueryResponses = new List<GetSupplierSupplyDetailReportQueryResponse>();

			foreach (var supplier in suppliers.ToList())
			{
				foreach (var stockInput in supplier.StockInputs.Where(x => x.IsActive == true && x.StockEntryDate >= request.StartDate && x.StockEntryDate <= request.EndDate).ToList())
				{
					getSupplierSupplyDetailReportQueryResponses.Add(new GetSupplierSupplyDetailReportQueryResponse
					{
						SupplierId = supplier.ID,
						BranchName = stockInput.Branch.BranchName,
						ProductName = stockInput.Product.ProductName,
						CompanyName = supplier.CompanyName,
						AppUserName = stockInput.AppUser.UserName,
						InoviceNumber = stockInput.InoviceNumber,
						Quantity = stockInput.Quantity,
						Description = stockInput.Description,
						StockEntryDate = stockInput.StockEntryDate
					});
				}
			}

			return getSupplierSupplyDetailReportQueryResponses;
		}
	}
}
