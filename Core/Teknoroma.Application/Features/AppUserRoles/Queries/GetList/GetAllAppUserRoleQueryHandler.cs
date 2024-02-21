using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.AppUserRoles.Queries.GetList
{
    public class GetAllAppUserRoleQueryHandler : IRequestHandler<GetAllAppUserRoleQueryRequest, List<GetAllAppUserRoleQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly RoleManager<AppUserRole> _roleManager;

        public GetAllAppUserRoleQueryHandler(IMapper mapper,RoleManager<AppUserRole> roleManager)
        {
            _mapper = mapper;
            _roleManager = roleManager;
        }
        public async Task<List<GetAllAppUserRoleQueryResponse>> Handle(GetAllAppUserRoleQueryRequest request, CancellationToken cancellationToken)
        {
            var appUserRoles = await _roleManager.Roles.ToListAsync();

            List<GetAllAppUserRoleQueryResponse> getAllAppUserRoleQueryResponses = _mapper.Map<List<GetAllAppUserRoleQueryResponse>>(appUserRoles);

            return getAllAppUserRoleQueryResponses;
        }
    }
}
