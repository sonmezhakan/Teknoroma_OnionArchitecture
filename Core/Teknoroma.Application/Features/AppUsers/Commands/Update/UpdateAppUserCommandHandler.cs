using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Teknoroma.Application.Features.AppUserProfiles.Command.Update;
using Teknoroma.Application.Features.AppUsers.Rules;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.AppUsers.Command.Update
{
    public class UpdateAppUserCommandHandler : IRequestHandler<UpdateAppUserCommandRequest, Unit>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly AppUserBusinessRules _appUserBusinessRules;

        public UpdateAppUserCommandHandler(IMediator mediator,IMapper mapper,UserManager<AppUser> userManager,AppUserBusinessRules appUserBusinessRules)
        {
            _mediator = mediator;
            _mapper = mapper;
            _userManager = userManager;
            _appUserBusinessRules = appUserBusinessRules;
        }

        public async Task<Unit> Handle(UpdateAppUserCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser appUser = await _userManager.FindByIdAsync(request.ID.ToString());

            await _appUserBusinessRules.EmailCannotBeDuplicatedWhenUpdated(appUser.Email, request.Email);
            await _appUserBusinessRules.PhoneNumberCannotBeDuplicatedWhenUpdated(appUser.PhoneNumber, request.PhoneNumber);

            request.UserName = appUser.UserName;
            appUser = _mapper.Map(request, appUser);

            var result = await _userManager.UpdateAsync(appUser);
            if (request.Password != null)
            {
                await _userManager.RemovePasswordAsync(appUser);
                await _userManager.AddPasswordAsync(appUser, request.Password);
            }

            if(result.Succeeded)
            {
                //Roles Updated 
                var currentRoles = await _userManager.GetRolesAsync(appUser);
                await _userManager.RemoveFromRolesAsync(appUser, currentRoles);
                await _userManager.AddToRolesAsync(appUser, request.AppUserRoles);

                //Profile Uptated
                UpdateAppUserProfileCommandRequest updateAppUserProfileCommandRequest = _mapper.Map<UpdateAppUserProfileCommandRequest>(request);

                await _mediator.Send(updateAppUserProfileCommandRequest);
            }

            return Unit.Value;

        }
    }
}
