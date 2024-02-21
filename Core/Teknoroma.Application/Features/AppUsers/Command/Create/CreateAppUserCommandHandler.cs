using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Teknoroma.Application.Features.AppUserProfiles.Command.Create;
using Teknoroma.Application.Features.AppUsers.Rules;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.AppUsers.Command.Create
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommandRequest, Unit>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly AppUserBusinessRules _appUserBusinessRules;
        private readonly IMediator _mediator;

        public CreateAppUserCommandHandler(IMapper mapper,UserManager<AppUser> userManager,AppUserBusinessRules appUserBusinessRules,IMediator mediator)
        {
            _mapper = mapper;
            _userManager = userManager;
            _appUserBusinessRules = appUserBusinessRules;
            _mediator = mediator;
        }
        public async Task<Unit> Handle(CreateAppUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _appUserBusinessRules.UserNameCannotBeDuplicatedWhenInserted(request.UserName);
            await _appUserBusinessRules.EmailCannotBeDuplicatedWhenInserted(request.Email);
            await _appUserBusinessRules.PhoneNumberCannotBeDuplicatedWhenInserted(request.PhoneNumber);

            AppUser appUser = _mapper.Map<AppUser>(request);

            var createAppUserReslt = await _userManager.CreateAsync(appUser, request.Password);

            //AppUserProfile Process
            if(createAppUserReslt.Succeeded)
            {
                await _mediator.Send(new CreateAppUserProfileCommandRequest
				{
					ID = appUser.Id,
					FirstName = request.FirstName,
					LastName = request.LastName,
				});
            }

            return Unit.Value;
        }
    }
}
