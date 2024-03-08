using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Stocks.Command.Create
{
    public class CreateStockCommandHandler : IRequestHandler<CreateStockCommandRequest, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IStockRepository _stockRepository;

        public CreateStockCommandHandler(IMapper mapper, IStockRepository stockRepository)
        {
            _mapper = mapper;
            _stockRepository = stockRepository;
        }
        public async Task<Unit> Handle(CreateStockCommandRequest request, CancellationToken cancellationToken)
        {
            Stock stock = _mapper.Map<Stock>(request);

            await _stockRepository.AddAsync(stock);
            return Unit.Value;
        }
    }
}
