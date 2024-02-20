using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.Branches.Rules;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Branches.Command.Create
{
	public class CreateBranchCommandHandler : IRequestHandler<CreateBranchCommandRequest, Unit>
	{
		private readonly IMapper _mapper;
		private readonly IBranchRepository _branchRepository;
		private readonly IProductRepository _productRepository;
		private readonly IStockRepository _stockRepository;
		private readonly BranchBusinessRules _branchBusinessRules;

		public CreateBranchCommandHandler(IMapper mapper,IBranchRepository branchRepository,IProductRepository productRepository,IStockRepository stockRepository,BranchBusinessRules branchBusinessRules)
        {
			_mapper = mapper;
			_branchRepository = branchRepository;
			_productRepository = productRepository;
			_stockRepository = stockRepository;
			_branchBusinessRules = branchBusinessRules;
		}
		public async Task<Unit> Handle(CreateBranchCommandRequest request, CancellationToken cancellationToken)
		{
			//BusinesRules
			await _branchBusinessRules.BranchNameCannotBeDuplicatedWhenInserted(request.BranchName);
			await _branchBusinessRules.PhoneNumberCannotBeDuplicatedWhenInserted(request.PhoneNumber);

			Branch branch = _mapper.Map<Branch>(request);

			await _branchRepository.AddAsync(branch);

			//Yeni eklenen şubeye tüm ürünler ekleniyor
			var products = await _productRepository.GetAllAsync();

			List<Stock> stocks = new List<Stock>();

			foreach (var product in products)
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
