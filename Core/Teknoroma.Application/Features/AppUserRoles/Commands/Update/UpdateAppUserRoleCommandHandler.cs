using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Teknoroma.Application.Features.AppUserRoles.Rules;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.AppUserRoles.Command.Update
{
    public class UpdateAppUserRoleCommandHandler : IRequestHandler<UpdateAppUserRoleCommandRequest, Unit>
    {
        private readonly IMapper _mapper;
        private readonly RoleManager<AppUserRole> _roleManager;
        private readonly AppUserRoleBusinessRules _appUserRoleBusinessRole;

        public UpdateAppUserRoleCommandHandler(IMapper mapper,RoleManager<AppUserRole> roleManager, AppUserRoleBusinessRules appUserRoleBusinessRole)
        {
            _mapper = mapper;
            _roleManager = roleManager;
            _appUserRoleBusinessRole = appUserRoleBusinessRole;
        }
        public async Task<Unit> Handle(UpdateAppUserRoleCommandRequest request, CancellationToken cancellationToken)
        {
            AppUserRole appUserRole = await _roleManager.FindByIdAsync(request.ID.ToString());

            await _appUserRoleBusinessRole.NameCannotBeDuplicatedWhenUpdated(appUserRole.Name,request.Name);

            appUserRole = _mapper.Map(request, appUserRole);

            await _roleManager.UpdateAsync(appUserRole);

            return Unit.Value;
        }
    }
}
