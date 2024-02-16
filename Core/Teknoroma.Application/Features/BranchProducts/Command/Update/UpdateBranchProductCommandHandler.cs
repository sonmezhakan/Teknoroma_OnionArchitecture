using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.BranchProducts.Command.Update
{
	public class UpdateBranchProductCommandHandler:IRequestHandler<UpdateBranchProductCommandRequest>
	{
		private readonly IMapper _mapper;
		private readonly IBranchProductRepository _branchProductRepository;

		public UpdateBranchProductCommandHandler(IMapper mapper, IBranchProductRepository branchProductRepository)
		{
			_mapper = mapper;
			_branchProductRepository = branchProductRepository;
		}

		public async Task<Unit> Handle(UpdateBranchProductCommandRequest request, CancellationToken cancellationToken)
		{
			BranchProduct branchProduct = await _branchProductRepository.GetAsync(x=>x.BranchId == request.BranchId && x.ProductId == request.ProductId);

			if(branchProduct != null)
			{
				if (request.Process == true)
				{
					branchProduct.UnitsInStock += request.Quantity;
				}
				else
				{
					branchProduct.UnitsInStock -= request.Quantity;
				}

				branchProduct = _mapper.Map(request, branchProduct);
				await _branchProductRepository.UpdateAsync(branchProduct);
			}

			return Unit.Value;
		}
	}
}
