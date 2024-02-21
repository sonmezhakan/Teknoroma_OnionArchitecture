using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Teknoroma.Application.Features.AppUserRoles.Rules;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.AppUserRoles.Command.Create
{
    public class CreateAppUserRoleCommandHandler : IRequestHandler<CreateAppUserRoleCommandRequest, Unit>
    {
        private readonly IMapper _mapper;
        private readonly RoleManager<AppUserRole> _roleManager;
        private readonly AppUserRoleBusinessRules _appUserRoleBusinessRole;

        public CreateAppUserRoleCommandHandler(IMapper mapper,RoleManager<AppUserRole> roleManager,AppUserRoleBusinessRules appUserRoleBusinessRole)
        {
            _mapper = mapper;
            _roleManager = roleManager;
            _appUserRoleBusinessRole = appUserRoleBusinessRole;
        }
        public async Task<Unit> Handle(CreateAppUserRoleCommandRequest request, CancellationToken cancellationToken)
        {
            await _appUserRoleBusinessRole.NameCannotBeDuplicatedWhenInserted(request.Name);

            AppUserRole appUserRole = _mapper.Map<AppUserRole>(request);

            await _roleManager.CreateAsync(appUserRole);

            return Unit.Value;
        }
    }
}
