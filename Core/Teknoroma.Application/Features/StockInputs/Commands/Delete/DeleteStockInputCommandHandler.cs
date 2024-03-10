using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.Stocks.Command.Update;
using Teknoroma.Application.Services.StockInputs;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.StockInputs.Command.Delete
{
	public class DeleteStockInputCommandHandler : IRequestHandler<DeleteStockInputCommandRequest, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
		private readonly IStockInputService _stockInputService;

		public DeleteStockInputCommandHandler(IMapper mapper,IMediator mediator,IStockInputService stockInputService)
        {
            _mapper = mapper;
            _mediator = mediator;
			_stockInputService = stockInputService;
		}
        public async Task<Unit> Handle(DeleteStockInputCommandRequest request, CancellationToken cancellationToken)
        {
            StockInput stockInput = await _stockInputService.GetAsync(x => x.ID == request.ID);

            //stock Process
            var stock = stockInput.Branch.stocks.FirstOrDefault(x=>x.BranchId == stockInput.BranchID && x.ProductId == stockInput.ProductID);
            stock.UnitsInStock -= stockInput.Quantity;
            UpdateStockCommandRequest updatestockCommandRequest = _mapper.Map<UpdateStockCommandRequest>(stock);
            await _mediator.Send(updatestockCommandRequest);

            await _stockInputService.DeleteAsync(stockInput);

            return Unit.Value;
        }
    }
}
