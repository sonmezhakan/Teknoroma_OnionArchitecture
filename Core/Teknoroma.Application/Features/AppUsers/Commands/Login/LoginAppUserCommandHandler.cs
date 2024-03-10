using MediatR;
using Microsoft.AspNetCore.Identity;
using Teknoroma.Application.Features.AppUsers.Rules;
using Teknoroma.Application.Security.JWTHelpers;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.AppUsers.Commands.Login
{
    public class LoginAppUserCommandHandler : IRequestHandler<LoginAppUserCommandRequest, LoginAppUserCommandResponse>
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly AppUserBusinessRules _appUserBusinessRules;
        private readonly IJwtService _jwtHelper;

        public LoginAppUserCommandHandler(UserManager<AppUser> userManager, AppUserBusinessRules appUserBusinessRules, IJwtService jwtHelper)
		{
			_userManager = userManager;
			_appUserBusinessRules = appUserBusinessRules;
           _jwtHelper = jwtHelper;
        }
		public async Task<LoginAppUserCommandResponse> Handle(LoginAppUserCommandRequest request, CancellationToken cancellationToken)
		{
			//business rules
			await _appUserBusinessRules.LoginCheckUserName(request.UserName);

			AppUser appUser = await _userManager.FindByNameAsync(request.UserName);

			await _appUserBusinessRules.LoginCheckPassword(appUser, request.Password);

			await _appUserBusinessRules.LoginCheckIsActive(appUser);

			string token = await _jwtHelper.GetJwtToken(appUser.Id, appUser.UserName);

			return new LoginAppUserCommandResponse
			{
				token = token
			};
		}

	}
}
