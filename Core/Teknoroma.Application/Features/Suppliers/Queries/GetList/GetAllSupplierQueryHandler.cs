using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Repositories;

namespace Teknoroma.Application.Features.Suppliers.Queries.GetList
{
    public class GetAllSupplierQueryHandler : IRequestHandler<GetAllSupplierQueryRequest, List<GetAllSupplierQueryResponse>>
	{
		private readonly IMapper _mapper;
		private readonly ISupplierRepository _supplierRepository;

		public GetAllSupplierQueryHandler(IMapper mapper,ISupplierRepository supplierRepository)
		{
			_mapper = mapper;
			_supplierRepository = supplierRepository;
		}

		public async Task<List<GetAllSupplierQueryResponse>> Handle(GetAllSupplierQueryRequest request, CancellationToken cancellationToken)
		{
			var suppliers = await _supplierRepository.GetAllAsync();

			List<GetAllSupplierQueryResponse> responses = _mapper.Map<List<GetAllSupplierQueryResponse>>(suppliers.ToList());

			return responses;
		}
	}
}
