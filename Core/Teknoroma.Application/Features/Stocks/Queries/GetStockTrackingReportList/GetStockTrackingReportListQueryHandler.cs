using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Repositories;

namespace Teknoroma.Application.Features.Stocks.Queries.GetStockTrackingReportList
{
    public class GetStockTrackingReportListQueryHandler : IRequestHandler<GetStockTrackingReportListQueryRequest, List<GetStockTrackingReportListQueryResponse>>
	{
		private readonly IMapper _mapper;
		private readonly IStockRepository _stockRepository;

		public GetStockTrackingReportListQueryHandler(IMapper mapper,IStockRepository stockRepository)
        {
			_mapper = mapper;
			_stockRepository = stockRepository;
		}
        public async Task<List<GetStockTrackingReportListQueryResponse>> Handle(GetStockTrackingReportListQueryRequest request, CancellationToken cancellationToken)
		{
			var stocks = await _stockRepository.GetAllAsync(x => x.BranchId == request.BranchId);

			List<GetStockTrackingReportListQueryResponse> getStockTrackingReportListQueryResponses = _mapper.Map<List<GetStockTrackingReportListQueryResponse>>(stocks.OrderBy(x=>x.UnitsInStock).ToList());

			return getStockTrackingReportListQueryResponses;
		}
	}
}
