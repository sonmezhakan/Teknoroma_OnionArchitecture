using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.AppUsers.Queries.GetById
{
	public class GetByIdAppUserQueryHandler : IRequestHandler<GetByIdAppUserQueryRequest, GetByIdAppUserQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public GetByIdAppUserQueryHandler(IMapper mapper,UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<GetByIdAppUserQueryResponse> Handle(GetByIdAppUserQueryRequest request, CancellationToken cancellationToken)
        {
            AppUser appUser = await _userManager.FindByIdAsync(request.ID.ToString());
            var appUserRole = await _userManager.GetRolesAsync(appUser);

            GetByIdAppUserQueryResponse getByIdAppUserQueryResponse = _mapper.Map<GetByIdAppUserQueryResponse>(appUser);
            getByIdAppUserQueryResponse.AppUserRoles = appUserRole.ToList();

            return getByIdAppUserQueryResponse;
        }
    }
}
