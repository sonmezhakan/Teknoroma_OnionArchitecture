using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Repositories;

namespace Teknoroma.Application.Features.Suppliers.Queries.GetListSelectIdAndName
{
    public class GetAllSelectIdAndNameSupplierQueryHandler : IRequestHandler<GetAllSelectIdAndNameSupplierQueryRequest, List<GetAllSelectIdAndNameSupplierQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ISupplierRepository _supplierRepository;

        public GetAllSelectIdAndNameSupplierQueryHandler(IMapper mapper,ISupplierRepository supplierRepository)
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
        }
        public async Task<List<GetAllSelectIdAndNameSupplierQueryResponse>> Handle(GetAllSelectIdAndNameSupplierQueryRequest request, CancellationToken cancellationToken)
        {
            var suppliers = await _supplierRepository.GetAllSelectIdAndNameAsync();

            List<GetAllSelectIdAndNameSupplierQueryResponse> getAllSelectIdAndNameSupplierQueryResponses = _mapper.Map<List<GetAllSelectIdAndNameSupplierQueryResponse>>(suppliers.ToList());

            return getAllSelectIdAndNameSupplierQueryResponses;
        }
    }
}
