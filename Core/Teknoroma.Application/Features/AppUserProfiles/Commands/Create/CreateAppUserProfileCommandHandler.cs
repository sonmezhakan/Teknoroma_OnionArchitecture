using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.AppUserProfiles.Rules;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.AppUserProfiles.Command.Create
{
	public class CreateAppUserProfileCommandHandler : IRequestHandler<CreateAppUserProfileCommandRequest, Unit>
    {
        private readonly IMapper _mapper;
		
		private readonly AppUserProfileBusinessRules _appUserProfileBusinessRules;
		private readonly IAppUserProfileRepository _appUserProfileRepository;

		public CreateAppUserProfileCommandHandler(IMapper mapper,AppUserProfileBusinessRules appUserProfileBusinessRules,IAppUserProfileRepository appUserProfileRepository)
        {
            _mapper = mapper;
			_appUserProfileBusinessRules = appUserProfileBusinessRules;
			_appUserProfileRepository = appUserProfileRepository;
		}
        public async Task<Unit> Handle(CreateAppUserProfileCommandRequest request, CancellationToken cancellationToken)
        {
            AppUserProfile appUserProfile = _mapper.Map<AppUserProfile>(request);

            await _appUserProfileRepository.AddAsync(appUserProfile);

            return Unit.Value;
        }
    }
}
