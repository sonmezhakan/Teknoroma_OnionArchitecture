using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Stocks.Command.Update
{
    public class UpdateStockCommandHandler : IRequestHandler<UpdateStockCommandRequest, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IStockRepository _stockRepository;

        public UpdateStockCommandHandler(IMapper mapper, IStockRepository stockRepository)
        {
            _mapper = mapper;
            _stockRepository = stockRepository;
        }

        public async Task<Unit> Handle(UpdateStockCommandRequest request, CancellationToken cancellationToken)
        {
            Stock stock = await _stockRepository.GetAsync(x => x.BranchId == request.BranchId && x.ProductId == request.ProductId);

            stock = _mapper.Map(request, stock);
            await _stockRepository.UpdateAsync(stock);

            return Unit.Value;
        }
    }
}
