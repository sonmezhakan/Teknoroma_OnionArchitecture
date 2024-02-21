using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Teknoroma.Application.Features.AppUserProfiles.Quıeries.GetList;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.AppUsers.Queries.GetList
{
    public class GetAllAppUserQueryHandler : IRequestHandler<GetAllAppUserQueryRequest, List<GetAllAppUserQueryResponse>>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public GetAllAppUserQueryHandler(IMediator mediator,IMapper mapper,UserManager<AppUser> userManager)
        {
            _mediator = mediator;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<List<GetAllAppUserQueryResponse>> Handle(GetAllAppUserQueryRequest request, CancellationToken cancellationToken)
        {
            var appUsers = await _userManager.Users.ToListAsync();
            var appUserProfiles = await _mediator.Send(new GetAllAppUserProfileQueryRequest());

            List<GetAllAppUserQueryResponse> getAllAppUserQueryResponses = new List<GetAllAppUserQueryResponse>();

            foreach (var item in appUsers)
            {
                var getAppUserProfile = appUserProfiles.FirstOrDefault(x => x.ID == item.Id);

                getAllAppUserQueryResponses.Add(new GetAllAppUserQueryResponse
                {
                    ID = item.Id,
                    UserName = item.UserName,
                    Email = item.Email,
                    PhoneNumber = item.PhoneNumber,
                    FirstName = getAppUserProfile.FirstName,
                    LastName = getAppUserProfile.LastName,
                    NationalityNumber = getAppUserProfile.NationalityNumber,
                    Address = getAppUserProfile.Address
                });
            }

            return getAllAppUserQueryResponses;
        }
    }
}
