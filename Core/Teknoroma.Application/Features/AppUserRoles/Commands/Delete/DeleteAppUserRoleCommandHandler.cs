using MediatR;
using Microsoft.AspNetCore.Identity;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.AppUserRoles.Command.Delete
{
    public class DeleteAppUserRoleCommandHandler : IRequestHandler<DeleteAppUserRoleCommandRequest, Unit>
    {
        private readonly RoleManager<AppUserRole> _roleManager;

        public DeleteAppUserRoleCommandHandler(RoleManager<AppUserRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<Unit> Handle(DeleteAppUserRoleCommandRequest request, CancellationToken cancellationToken)
        {
            AppUserRole appUserRole = await _roleManager.FindByIdAsync(request.ID.ToString());

            if(appUserRole != null)
                await _roleManager.DeleteAsync(appUserRole);

            return Unit.Value;
        }
    }
}
