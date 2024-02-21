using AutoMapper;
using MediatR;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.AppUserProfiles.Command.Delete
{
    public class DeleteAppUserProfileCommandHandler : IRequestHandler<DeleteAppUserProfileCommandRequest, Unit>
    {
        private readonly IAppUserProfileRepository _appUserProfileRepository;

        public DeleteAppUserProfileCommandHandler(IAppUserProfileRepository appUserProfileRepository)
        {
            _appUserProfileRepository = appUserProfileRepository;
        }
        public async Task<Unit> Handle(DeleteAppUserProfileCommandRequest request, CancellationToken cancellationToken)
        {
            AppUserProfile appUserProfile = await _appUserProfileRepository.GetAsync(x => x.ID == request.ID);

            await _appUserProfileRepository.DeleteAsync(appUserProfile);

            return Unit.Value;
        }
    }
}
