using AutoMapper;
using MediatR;
using Teknoroma.Application.Repositories;

namespace Teknoroma.Application.Features.Suppliers.Queries.GetById
{
	public class GetByIdSupplierQueryHandler : IRequestHandler<GetByIdSupplierQueryRequest, GetByIdSupplierQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly ISupplierRepository _supplierRepository;

		public GetByIdSupplierQueryHandler(IMapper mapper,ISupplierRepository supplierRepository)
        {
			_mapper = mapper;
			_supplierRepository = supplierRepository;
		}
        public async Task<GetByIdSupplierQueryResponse> Handle(GetByIdSupplierQueryRequest request, CancellationToken cancellationToken)
		{
			Teknoroma.Domain.Entities.Supplier supplier = await _supplierRepository.GetAsync(x=>x.ID == request.ID);

			GetByIdSupplierQueryResponse response = _mapper.Map<GetByIdSupplierQueryResponse>(supplier);

			return response;
		}
	}
}
