using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.Branches.Queries.GetAll;
using Teknoroma.Application.Repositories;

namespace Teknoroma.Application.Features.Branches.Queries.GetList
{
	public class GetAllBranchQueryHandler:IRequestHandler<GetAllBranchQueryRequest, List<GetAllBranchQueryResponse>>
	{
		private readonly IMapper _mapper;
		private readonly IBranchRepository _branchRepository;

		public GetAllBranchQueryHandler(IMapper mapper, IBranchRepository branchRepository)
        {
			_mapper = mapper;
			_branchRepository = branchRepository;
		}

		public async Task<List<GetAllBranchQueryResponse>> Handle(GetAllBranchQueryRequest request, CancellationToken cancellationToken)
		{
			var branches = await _branchRepository.GetAllAsync();

			List<GetAllBranchQueryResponse> responses = _mapper.Map<List<GetAllBranchQueryResponse>>(branches.ToList());

			return responses;
		}
	}
}
