using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Teknoroma.Application.Features.AppUserProfiles.Quıeries.GetById;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.AppUsers.Queries.GetById
{
    public class GetByIdAppUserQueryHandler : IRequestHandler<GetByIdAppUserQueryRequest, GetByIdAppUserQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMediator _mediator;

        public GetByIdAppUserQueryHandler(IMapper mapper,UserManager<AppUser> userManager,IMediator mediator)
        {
            _mapper = mapper;
            _userManager = userManager;
            _mediator = mediator;
        }
        public async Task<GetByIdAppUserQueryResponse> Handle(GetByIdAppUserQueryRequest request, CancellationToken cancellationToken)
        {
            AppUser appUser = await _userManager.FindByIdAsync(request.ID.ToString());

            var getAppUserProfile = await _mediator.Send(new GetByIdAppUserProfileQueryRequest { ID = request.ID });

            GetByIdAppUserQueryResponse getByIdAppUserQueryResponse = new GetByIdAppUserQueryResponse();
            _mapper.Map(appUser, getByIdAppUserQueryResponse);
            _mapper.Map(getAppUserProfile, getByIdAppUserQueryResponse);

            return getByIdAppUserQueryResponse;
        }
    }
}
