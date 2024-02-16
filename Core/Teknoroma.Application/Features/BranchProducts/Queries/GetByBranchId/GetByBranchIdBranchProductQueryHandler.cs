using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Features.BranchProducts.Queries.GetByBranchId;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.BranchProducts.Queries.GetByBranchId
{
	public class GetByIdBranchProductQueryHandler:IRequestHandler<GetByIdBranchProductQueryRequest, GetByBranchIdBranchProductQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IBranchProductRepository _branchProductRepository;

		public GetByIdBranchProductQueryHandler(IMapper mapper,IBranchProductRepository branchProductRepository)
        {
			_mapper = mapper;
			_branchProductRepository = branchProductRepository;
		}

		public async Task<GetByBranchIdBranchProductQueryResponse> Handle(GetByIdBranchProductQueryRequest request, CancellationToken cancellationToken)
		{
			BranchProduct branchProduct = await _branchProductRepository.GetAsync(x => x.BranchId == request.BranchID);

			GetByBranchIdBranchProductQueryResponse response = _mapper.Map<GetByBranchIdBranchProductQueryResponse>(branchProduct);

			return response;
		}
	}
}
