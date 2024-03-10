using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Suppliers;

namespace Teknoroma.Application.Features.Suppliers.Queries.GetList
{
	public class GetAllSupplierQueryHandler : IRequestHandler<GetAllSupplierQueryRequest, List<GetAllSupplierQueryResponse>>
	{
		private readonly IMapper _mapper;
		private readonly ISupplierService _supplierService;

		public GetAllSupplierQueryHandler(IMapper mapper,ISupplierService supplierService)
		{
			_mapper = mapper;
			_supplierService = supplierService;
		}

		public async Task<List<GetAllSupplierQueryResponse>> Handle(GetAllSupplierQueryRequest request, CancellationToken cancellationToken)
		{
			var suppliers = await _supplierService.GetAllAsync();

			List<GetAllSupplierQueryResponse> responses = _mapper.Map<List<GetAllSupplierQueryResponse>>(suppliers.ToList());

			return responses;
		}
	}
}
