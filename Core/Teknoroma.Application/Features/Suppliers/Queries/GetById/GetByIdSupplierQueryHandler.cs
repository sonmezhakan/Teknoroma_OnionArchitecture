using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Suppliers;

namespace Teknoroma.Application.Features.Suppliers.Queries.GetById
{
	public class GetByIdSupplierQueryHandler : IRequestHandler<GetByIdSupplierQueryRequest, GetByIdSupplierQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly ISupplierService _supplierService;

		public GetByIdSupplierQueryHandler(IMapper mapper, ISupplierService supplierService)
        {
			_mapper = mapper;
			_supplierService = supplierService;
		}
        public async Task<GetByIdSupplierQueryResponse> Handle(GetByIdSupplierQueryRequest request, CancellationToken cancellationToken)
		{
			Teknoroma.Domain.Entities.Supplier supplier = await _supplierService.GetAsync(x=>x.ID == request.ID);

			GetByIdSupplierQueryResponse response = _mapper.Map<GetByIdSupplierQueryResponse>(supplier);

			return response;
		}
	}
}
