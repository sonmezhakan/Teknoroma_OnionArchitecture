using MediatR;
using Microsoft.AspNetCore.Identity;
using Teknoroma.Application.Features.AppUsers.Rules;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.AppUsers.Commands.Login
{
    public class LoginAppUserCommandHandler : IRequestHandler<LoginAppUserCommandRequest, LoginAppUserCommandResponse>
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly AppUserBusinessRules _appUserBusinessRules;

		public LoginAppUserCommandHandler(UserManager<AppUser> userManager, AppUserBusinessRules appUserBusinessRules)
		{
			_userManager = userManager;
			_appUserBusinessRules = appUserBusinessRules;
		}
		public async Task<LoginAppUserCommandResponse> Handle(LoginAppUserCommandRequest request, CancellationToken cancellationToken)
		{
			//business rules
			await _appUserBusinessRules.LoginCheckUserName(request.UserName);

			AppUser appUser = await _userManager.FindByNameAsync(request.UserName);

			await _appUserBusinessRules.LoginCheckPassword(appUser, request.Password);

			return new LoginAppUserCommandResponse
			{
				ID= appUser.Id,
				UserName = appUser.UserName
			};
		}

	}
}
