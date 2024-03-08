using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.Branches.Queries.GetAll;
using Teknoroma.Application.Services.Branches;

namespace Teknoroma.Application.Features.Branches.Queries.GetList
{
	public class GetAllBranchQueryHandler:IRequestHandler<GetAllBranchQueryRequest, List<GetAllBranchQueryResponse>>
	{
		private readonly IMapper _mapper;
		private readonly IBranchService _branchService;

		public GetAllBranchQueryHandler(IMapper mapper, IBranchService branchService)
        {
			_mapper = mapper;
			_branchService = branchService;
		}

		public async Task<List<GetAllBranchQueryResponse>> Handle(GetAllBranchQueryRequest request, CancellationToken cancellationToken)
		{
			var branches = await _branchService.GetAllAsync();

			List<GetAllBranchQueryResponse> responses = _mapper.Map<List<GetAllBranchQueryResponse>>(branches.ToList());

			return responses;
		}
	}
}
