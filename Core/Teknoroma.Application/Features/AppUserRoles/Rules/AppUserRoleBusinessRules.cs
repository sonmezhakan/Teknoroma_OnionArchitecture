using Microsoft.AspNetCore.Identity;
using Teknoroma.Application.Exceptions.Types;
using Teknoroma.Application.Features.AppUserRoles.Contants;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.AppUserRoles.Rules
{
    public class AppUserRoleBusinessRules
    {
        private readonly RoleManager<AppUserRole> _roleManager;

        public AppUserRoleBusinessRules(RoleManager<AppUserRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task NameCannotBeDuplicatedWhenInserted(string name)
        {
            var result = await _roleManager.FindByNameAsync(name);

            if (result != null)
                throw new BusinessException(AppUserRolesMessages.NameExists);
        }
        public async Task NameCannotBeDuplicatedWhenUpdated(string oldName, string newName)
        {
            if(oldName != newName)
            {
                var result = await _roleManager.FindByNameAsync(newName);

                if (result != null)
                    throw new BusinessException(AppUserRolesMessages.NameExists);
            }
        }
    }
}
