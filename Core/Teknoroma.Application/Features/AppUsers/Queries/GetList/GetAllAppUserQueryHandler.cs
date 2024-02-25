using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Teknoroma.Application.Features.AppUserProfiles.Quıeries.GetList;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.AppUsers.Queries.GetList
{
    public class GetAllAppUserQueryHandler : IRequestHandler<GetAllAppUserQueryRequest, List<GetAllAppUserQueryResponse>>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public GetAllAppUserQueryHandler(IMediator mediator,IMapper mapper,UserManager<AppUser> userManager)
        {
            _mediator = mediator;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<List<GetAllAppUserQueryResponse>> Handle(GetAllAppUserQueryRequest request, CancellationToken cancellationToken)
        {
            var appUsers = await _userManager.Users.ToListAsync();

            List<GetAllAppUserQueryResponse> getAllAppUserQueryResponses = _mapper.Map<List<GetAllAppUserQueryResponse>>(appUsers.ToList());

			return getAllAppUserQueryResponses;
        }
    }
}
