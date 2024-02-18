using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
		private readonly IBranchProductRepository _branchProductRepository;
		private readonly BranchBusinessRules _branchBusinessRules;

		public CreateBranchCommandHandler(IMapper mapper,IBranchRepository branchRepository,IProductRepository productRepository,IBranchProductRepository branchProductRepository,BranchBusinessRules branchBusinessRules)
        {
			_mapper = mapper;
			_branchRepository = branchRepository;
			_productRepository = productRepository;
			_branchProductRepository = branchProductRepository;
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

			List<BranchProduct> branchProducts = new List<BranchProduct>();

			foreach (var product in products)
			{
				branchProducts.Add(new BranchProduct
				{
					BranchId = branch.ID,
					ProductId = product.ID,
					IsActive = product.IsActive
				});
			}

			await _branchProductRepository.AddRangeAsync(branchProducts);

			return Unit.Value;
		}
	}
}
