using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.AppUserRoles.Queries.GetById
{
    public class GetByIdAppUserRoleQueryHandler : IRequestHandler<GetByIdAppUserRoleQueryRequest, GetByIdAppUserRoleQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly RoleManager<AppUserRole> _roleManager;

        public GetByIdAppUserRoleQueryHandler(IMapper mapper,RoleManager<AppUserRole> roleManager)
        {
            _mapper = mapper;
            _roleManager = roleManager;
        }

        public async Task<GetByIdAppUserRoleQueryResponse> Handle(GetByIdAppUserRoleQueryRequest request, CancellationToken cancellationToken)
        {
            AppUserRole appUserRole = await _roleManager.FindByIdAsync(request.ID.ToString());

            GetByIdAppUserRoleQueryResponse getByIdAppUserRoleQueryResponse = _mapper.Map<GetByIdAppUserRoleQueryResponse>(appUserRole);

            return getByIdAppUserRoleQueryResponse;
        }
    }
}
