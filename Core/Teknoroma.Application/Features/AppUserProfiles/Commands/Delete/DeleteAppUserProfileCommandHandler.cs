using MediatR;
using Teknoroma.Application.Services.AppUserProfiles;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.AppUserProfiles.Command.Delete
{
	public class DeleteAppUserProfileCommandHandler : IRequestHandler<DeleteAppUserProfileCommandRequest, Unit>
    {
		private readonly IAppUserProfileService _appUserProfileService;

		public DeleteAppUserProfileCommandHandler(IAppUserProfileService appUserProfileService)
        {
			_appUserProfileService = appUserProfileService;
		}
        public async Task<Unit> Handle(DeleteAppUserProfileCommandRequest request, CancellationToken cancellationToken)
        {
            AppUserProfile appUserProfile = await _appUserProfileService.GetAsync(x => x.ID == request.ID);

            await _appUserProfileService.DeleteAsync(appUserProfile);

            return Unit.Value;
        }
    }
}
