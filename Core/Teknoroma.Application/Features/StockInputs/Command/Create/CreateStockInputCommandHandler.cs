using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.Products.Command.Update;
using Teknoroma.Application.Features.Products.Queries.GetById;
using Teknoroma.Application.Features.Stocks.Command.Update;
using Teknoroma.Application.Features.Stocks.Queries.GetById;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.StockInputs.Command.Create
{
    public class CreateStockInputCommandHandler : IRequestHandler<CreateStockInputCommandRequest, Unit>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IStockInputRepository _stockInputRepository;

        public CreateStockInputCommandHandler(IMediator mediator,IMapper mapper,IStockInputRepository stockInputRepository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _stockInputRepository = stockInputRepository;
        }
        public async Task<Unit> Handle(CreateStockInputCommandRequest request, CancellationToken cancellationToken)
        {
            StockInput stockInput = _mapper.Map<StockInput>(request);

            await _stockInputRepository.AddAsync(stockInput);

            //stock Process
            var stock = await _mediator.Send(new GetByIdStockQueryRequest { BranchID = request.BranchID, ProductID = request.ProductID });
            stock.UnitsInStock += request.Quantity;
            UpdateStockCommandRequest updatestockCommandRequest = _mapper.Map<UpdateStockCommandRequest>(stock);
            await _mediator.Send(updatestockCommandRequest);

            //Product Process
            var product = await _mediator.Send(new GetByIdProductQueryRequest { ID = request.ProductID });
            product.UnitsInStock += request.Quantity;
            UpdateProductCommandRequest updateProduct = _mapper.Map<UpdateProductCommandRequest>(product);
            await _mediator.Send(updateProduct);

            return Unit.Value;
        }
    }
}
