using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Branches.Queries.GetListSelectIdAndName
{
    internal class GetAllSelectIdAndNameBranchQueryHandler : IRequestHandler<GetAllSelectIdAndNameBranchQueryRequest, List<GetAllSelectIdAndNameBranchQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBranchRepository _branchRepository;

        public GetAllSelectIdAndNameBranchQueryHandler(IMapper mapper, IBranchRepository branchRepository)
        {
            _mapper = mapper;
            _branchRepository = branchRepository;
        }
        public async Task<List<GetAllSelectIdAndNameBranchQueryResponse>> Handle(GetAllSelectIdAndNameBranchQueryRequest request, CancellationToken cancellationToken)
        {
            var branches = await _branchRepository.GetAllSelectIdAndNameAsync();

            List<GetAllSelectIdAndNameBranchQueryResponse> getAllSelectIdAndNameBranchQueryResponses = _mapper.Map<List<GetAllSelectIdAndNameBranchQueryResponse>>(branches.ToList());

            return getAllSelectIdAndNameBranchQueryResponses;
        }
    }
}
