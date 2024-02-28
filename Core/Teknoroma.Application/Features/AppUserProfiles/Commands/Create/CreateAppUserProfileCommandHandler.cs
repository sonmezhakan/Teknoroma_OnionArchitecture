﻿using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.AppUserProfiles.Rules;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.AppUserProfiles.Command.Create
{
    public class CreateAppUserProfileCommandHandler : IRequestHandler<CreateAppUserProfileCommandRequest, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IAppUserProfileRepository _appUserProfileRepository;
        private readonly AppUserProfileBusinessRules _appUserProfileBusinessRules;

        public CreateAppUserProfileCommandHandler(IMapper mapper,IAppUserProfileRepository appUserProfileRepository,AppUserProfileBusinessRules appUserProfileBusinessRules)
        {
            _mapper = mapper;
            _appUserProfileRepository = appUserProfileRepository;
            _appUserProfileBusinessRules = appUserProfileBusinessRules;
        }
        public async Task<Unit> Handle(CreateAppUserProfileCommandRequest request, CancellationToken cancellationToken)
        {
            AppUserProfile appUserProfile = _mapper.Map<AppUserProfile>(request);

            await _appUserProfileRepository.AddAsync(appUserProfile);

            return Unit.Value;
        }
    }
}