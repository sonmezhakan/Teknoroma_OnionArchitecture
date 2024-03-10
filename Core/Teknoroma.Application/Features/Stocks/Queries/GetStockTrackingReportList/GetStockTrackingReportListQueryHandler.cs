using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Stocks;

namespace Teknoroma.Application.Features.Stocks.Queries.GetStockTrackingReportList
{
	public class GetStockTrackingReportListQueryHandler : IRequestHandler<GetStockTrackingReportListQueryRequest, List<GetStockTrackingReportListQueryResponse>>
	{
		private readonly IMapper _mapper;
		private readonly IStockService _stockService;

		public GetStockTrackingReportListQueryHandler(IMapper mapper,IStockService stockService)
        {
			_mapper = mapper;
			_stockService = stockService;
		}
        public async Task<List<GetStockTrackingReportListQueryResponse>> Handle(GetStockTrackingReportListQueryRequest request, CancellationToken cancellationToken)
		{
			var stocks = await _stockService.GetAllAsync(x => x.BranchId == request.BranchId);

			List<GetStockTrackingReportListQueryResponse> getStockTrackingReportListQueryResponses = _mapper.Map<List<GetStockTrackingReportListQueryResponse>>(stocks.OrderBy(x=>x.UnitsInStock).ToList());

			return getStockTrackingReportListQueryResponses;
		}
	}
}
