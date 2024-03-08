using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.Products.Command.Update;
using Teknoroma.Application.Features.Stocks.Command.Update;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.StockInputs.Command.Update
{
    public class UpdateStockInputCommandHandler:IRequestHandler<UpdateStockInputCommandRequest,Unit>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IStockInputRepository _stockInputRepository;

        public UpdateStockInputCommandHandler(IMediator mediator,IMapper mapper,IStockInputRepository stockInputRepository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _stockInputRepository = stockInputRepository;
        }

        public async Task<Unit> Handle(UpdateStockInputCommandRequest request, CancellationToken cancellationToken)
        {
            StockInput stockInput = await _stockInputRepository.GetAsync(x => x.ID == request.ID);

            //stock Process
            var stock = stockInput.Branch.stocks.FirstOrDefault(x => x.BranchId == request.BranchID && x.ProductId == request.ProductID);
            stock.UnitsInStock += stockInput.Quantity;
            stock.UnitsInStock -= request.Quantity;
            UpdateStockCommandRequest updatestockCommandRequest = _mapper.Map<UpdateStockCommandRequest>(stock);
            await _mediator.Send(updatestockCommandRequest);

            //StockInput Process
            stockInput = _mapper.Map(request, stockInput);

            await _stockInputRepository.UpdateAsync(stockInput);

            return Unit.Value;
        }
    }
}
