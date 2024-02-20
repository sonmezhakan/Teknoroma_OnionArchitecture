using AutoMapper;
using MediatR;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Products.Command.Create
{
	public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, Unit>
	{
		private readonly IMapper _mapper;
		private readonly IProductRepository _productRepository;
		private readonly IBranchRepository _branchRepository;
		private readonly IStockRepository _stockRepository;

		public CreateProductCommandHandler(IMapper mapper,IProductRepository productRepository,IBranchRepository branchRepository,IStockRepository stockRepository)
        {
			_mapper = mapper;
			_productRepository = productRepository;
			_branchRepository = branchRepository;
			_stockRepository = stockRepository;
		}
        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
		{
			Product product = _mapper.Map<Product>(request);

			await _productRepository.AddAsync(product);



			//Tüm şubelere ürünün eklenmesi sağlanıyor
			var branches = await _branchRepository.GetAllAsync();

			List<Stock> stocks = new List<Stock>();

			foreach (var branch in branches)
			{
				stocks.Add(new Stock
				{
					BranchId = branch.ID,
					ProductId = product.ID,
					IsActive = product.IsActive
				});
			}

			await _stockRepository.AddRangeAsync(stocks);

			return Unit.Value;
		}
	}
}
