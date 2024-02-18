using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Products.Command.Create
{
	public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, Unit>
	{
		private readonly IMapper _mapper;
		private readonly IProductRepository _productRepository;
		private readonly IBranchRepository _branchRepository;
		private readonly IBranchProductRepository _branchProductRepository;

		public CreateProductCommandHandler(IMapper mapper,IProductRepository productRepository,IBranchRepository branchRepository,IBranchProductRepository branchProductRepository)
        {
			_mapper = mapper;
			_productRepository = productRepository;
			_branchRepository = branchRepository;
			_branchProductRepository = branchProductRepository;
		}
        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
		{
			Product product = _mapper.Map<Product>(request);

			await _productRepository.AddAsync(product);

			//Tüm şubelere ürünün eklenmesi sağlanıyor
			var branches = await _branchRepository.GetAllAsync();

			List<BranchProduct> branchProducts = new List<BranchProduct>();

			foreach (var branch in branches)
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
