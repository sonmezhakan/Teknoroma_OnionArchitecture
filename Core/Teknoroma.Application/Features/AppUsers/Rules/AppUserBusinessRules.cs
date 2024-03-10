using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Teknoroma.Application.Exceptions.Types;
using Teknoroma.Application.Features.AppUsers.Contants;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.AppUsers.Rules
{
    public class AppUserBusinessRules
    {
        private readonly UserManager<AppUser> _userManager;

        public AppUserBusinessRules(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task UserNameCannotBeDuplicatedWhenInserted(string userName)
        {
            var result = await _userManager.FindByNameAsync(userName);

            if (result != null)
                throw new BusinessException(AppUsersMessages.UserNameExists);
        }
        public async Task EmailCannotBeDuplicatedWhenInserted(string email)
        {
            var result = await _userManager.FindByEmailAsync(email);

            if (result != null)
                throw new BusinessException(AppUsersMessages.EmailExists);
        }
        public async Task EmailCannotBeDuplicatedWhenUpdated(string oldEmail, string newEmail)
        {
            if(oldEmail != newEmail)
            {
                var result = await _userManager.FindByEmailAsync(newEmail);

                if (result != null)
                    throw new BusinessException(AppUsersMessages.EmailExists);
            }
        }
        public async Task PhoneNumberCannotBeDuplicatedWhenInserted(string? phoneNumber)
        {
            if (phoneNumber != null)
            {
                bool result = await _userManager.Users.AnyAsync(x=>x.PhoneNumber ==  phoneNumber);

                if (result)
                    throw new BusinessException(AppUsersMessages.PhoneNumberExists);
            }
        }

        public async Task PhoneNumberCannotBeDuplicatedWhenUpdated(string oldPhoneNumber, string newPhoneNumber)
        {
            if (oldPhoneNumber != newPhoneNumber)
            {
                bool result = await _userManager.Users.AnyAsync(x => x.PhoneNumber == newPhoneNumber);

                if (result)
                    throw new BusinessException(AppUsersMessages.PhoneNumberExists);
            }
        }

        public async Task LoginCheckUserName(string userName)
        {
            var result = await _userManager.FindByNameAsync(userName);

            if (result == null)
                throw new BusinessException(AppUsersMessages.UserNameNotFound);
        }
        public async Task LoginCheckPassword(AppUser appUser,string password)
        {
            bool result = await _userManager.CheckPasswordAsync(appUser, password);

            if (!result)
                throw new BusinessException(AppUsersMessages.PasswordError);
        }
        public async Task LoginCheckIsActive(AppUser appUser)
        {
            if (appUser.Employee.IsActive != true)
                throw new BusinessException(AppUsersMessages.EmployeeDontWork);
        }
    }
}
