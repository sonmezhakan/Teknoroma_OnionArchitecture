using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Branches.Queries.GetById
{
	public class GetByIdBranchQueryHandler:IRequestHandler<GetByIdBranchQueryRequest,GetByIdBranchQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IBranchRepository _branchRepository;

		public GetByIdBranchQueryHandler(IMapper mapper,IBranchRepository branchRepository)
        {
			_mapper = mapper;
			_branchRepository = branchRepository;
		}

		public async Task<GetByIdBranchQueryResponse> Handle(GetByIdBranchQueryRequest request, CancellationToken cancellationToken)
		{
			Branch branch = await _branchRepository.GetAsync(x=>x.ID == request.ID);

			GetByIdBranchQueryResponse response = _mapper.Map<GetByIdBranchQueryResponse>(branch);

			return response;
		}
	}
}
