using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Branches.Command.Create
{
	public class CreateBranchCommandHandler : IRequestHandler<CreateBranchCommandRequest, string>
	{
		private readonly IMapper _mapper;
		private readonly IBranchRepository _branchRepository;
		private readonly IProductRepository _productRepository;
		private readonly IBranchProductRepository _branchProductRepository;

		public CreateBranchCommandHandler(IMapper mapper,IBranchRepository branchRepository,IProductRepository productRepository,IBranchProductRepository branchProductRepository)
        {
			_mapper = mapper;
			_branchRepository = branchRepository;
			_productRepository = productRepository;
			_branchProductRepository = branchProductRepository;
		}
		public async Task<string> Handle(CreateBranchCommandRequest request, CancellationToken cancellationToken)
		{
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

			return "Kayıt Başarılı!";
		}
	}
}
