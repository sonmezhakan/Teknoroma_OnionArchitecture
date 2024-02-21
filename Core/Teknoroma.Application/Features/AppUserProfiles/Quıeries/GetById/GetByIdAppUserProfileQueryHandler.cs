using AutoMapper;
using MediatR;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.AppUserProfiles.Quıeries.GetById
{
    public class GetByIdAppUserProfileQueryHandler : IRequestHandler<GetByIdAppUserProfileQueryRequest, GetByIdAppUserProfileQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAppUserProfileRepository _appUserProfileRepository;

        public GetByIdAppUserProfileQueryHandler(IMapper mapper,IAppUserProfileRepository appUserProfileRepository)
        {
            _mapper = mapper;
            _appUserProfileRepository = appUserProfileRepository;
        }

        public async Task<GetByIdAppUserProfileQueryResponse> Handle(GetByIdAppUserProfileQueryRequest request, CancellationToken cancellationToken)
        {
            AppUserProfile appUserProfile = await _appUserProfileRepository.GetAsync(x => x.ID == request.ID);

            GetByIdAppUserProfileQueryResponse appUserProfileQueryResponse = _mapper.Map<GetByIdAppUserProfileQueryResponse>(appUserProfile);

            return appUserProfileQueryResponse;
        }
    }
}
