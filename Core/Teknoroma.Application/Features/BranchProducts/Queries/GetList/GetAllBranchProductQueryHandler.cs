using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Repositories;

namespace Teknoroma.Application.Features.BranchProducts.Queries.GetList
{
	public class GetAllBranchProductQueryHandler : IRequestHandler<GetAllBranchProductQueryRequest, List<GetAllBranchProductQueryResponse>>
	{
		private readonly IMapper _mapper;
		private readonly IBranchProductRepository _branchProductRepository;

		public GetAllBranchProductQueryHandler(IMapper mapper, IBranchProductRepository branchProductRepository)
        {
			_mapper = mapper;
			_branchProductRepository = branchProductRepository;
		}
        public async Task<List<GetAllBranchProductQueryResponse>> Handle(GetAllBranchProductQueryRequest request, CancellationToken cancellationToken)
		{
			var branchProducts = await _branchProductRepository.GetAllAsync();

			List<GetAllBranchProductQueryResponse> responses = _mapper.Map<List<GetAllBranchProductQueryResponse>>(branchProducts);

			return responses;
		}
	}
}
