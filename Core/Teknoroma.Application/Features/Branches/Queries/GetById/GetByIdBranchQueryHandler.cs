using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Branches;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Branches.Queries.GetById
{
	public class GetByIdBranchQueryHandler:IRequestHandler<GetByIdBranchQueryRequest,GetByIdBranchQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IBranchService _branchService;
		

		public GetByIdBranchQueryHandler(IMapper mapper,IBranchService branchService)
        {
			_mapper = mapper;
			_branchService = branchService;			
		}

		public async Task<GetByIdBranchQueryResponse> Handle(GetByIdBranchQueryRequest request, CancellationToken cancellationToken)
		{
			Branch branch = await _branchService.GetAsync(x=>x.ID == request.ID);

			GetByIdBranchQueryResponse response = _mapper.Map<GetByIdBranchQueryResponse>(branch);

			return response;
		}
	}
}
