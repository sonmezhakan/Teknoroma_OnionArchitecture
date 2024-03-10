using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.Stocks.Command.Update;
using Teknoroma.Application.Services.StockInputs;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.StockInputs.Command.Update
{
	public class UpdateStockInputCommandHandler:IRequestHandler<UpdateStockInputCommandRequest,Unit>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
		private readonly IStockInputService _stockInputService;

		public UpdateStockInputCommandHandler(IMediator mediator,IMapper mapper,IStockInputService stockInputService)
        {
            _mediator = mediator;
            _mapper = mapper;
			_stockInputService = stockInputService;
		}

        public async Task<Unit> Handle(UpdateStockInputCommandRequest request, CancellationToken cancellationToken)
        {
            StockInput stockInput = await _stockInputService.GetAsync(x => x.ID == request.ID);

            //stock Process
            var stock = stockInput.Branch.stocks.FirstOrDefault(x => x.BranchId == request.BranchID && x.ProductId == request.ProductID);
            stock.UnitsInStock += stockInput.Quantity;
            stock.UnitsInStock -= request.Quantity;
            UpdateStockCommandRequest updatestockCommandRequest = _mapper.Map<UpdateStockCommandRequest>(stock);
            await _mediator.Send(updatestockCommandRequest);

            //StockInput Process
            stockInput = _mapper.Map(request, stockInput);

            await _stockInputService.UpdateAsync(stockInput);

            return Unit.Value;
        }
    }
}
