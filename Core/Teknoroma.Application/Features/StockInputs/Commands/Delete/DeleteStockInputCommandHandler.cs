using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.Stocks.Command.Update;
using Teknoroma.Application.Services.Repositories;

namespace Teknoroma.Application.Features.StockInputs.Command.Delete
{
	public class DeleteStockInputCommandHandler : IRequestHandler<DeleteStockInputCommandRequest, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
		private readonly IStockInputRepository _stockInputRepository;

		public DeleteStockInputCommandHandler(IMapper mapper,IMediator mediator,IStockInputRepository stockInputRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
			_stockInputRepository = stockInputRepository;
		}
        public async Task<Unit> Handle(DeleteStockInputCommandRequest request, CancellationToken cancellationToken)
        {
            var stockInput = await _stockInputRepository.GetAsync(x => x.ID == request.ID);

            //stock Process
            var stock = stockInput.Branch.stocks.FirstOrDefault(x=>x.BranchId == stockInput.BranchID && x.ProductId == stockInput.ProductID);
            stock.UnitsInStock -= stockInput.Quantity;
			UpdateStockCommandRequest updatestockCommandRequest = _mapper.Map<UpdateStockCommandRequest>(stock);
			await _mediator.Send(updatestockCommandRequest);

			await _stockInputRepository.DeleteAsync(stockInput);

            return Unit.Value;
        }
    }
}
