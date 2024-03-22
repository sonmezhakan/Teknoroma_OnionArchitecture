using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.AppUsers.Queries.GetListSelectIdAndName
{
    public class GetAllSelectIdAndNameAppUserQueryHandler : IRequestHandler<GetAllSelectIdAndNameAppUserQueryRequest, List<GetAllSelectIdAndNameAppUserQueryResponse>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public GetAllSelectIdAndNameAppUserQueryHandler(UserManager<AppUser> userManager,IMapper mapper)
        {
           _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<List<GetAllSelectIdAndNameAppUserQueryResponse>> Handle(GetAllSelectIdAndNameAppUserQueryRequest request, CancellationToken cancellationToken)
        {
            var users = await _userManager.Users.Select(x => new AppUser
            {
                Id = x.Id,
                UserName = x.UserName
            }).ToListAsync();

            List<GetAllSelectIdAndNameAppUserQueryResponse> getAllSelectIdAndNameAppUserQueryResponses = _mapper.Map<List<GetAllSelectIdAndNameAppUserQueryResponse>>(users);

            return getAllSelectIdAndNameAppUserQueryResponses;
        }
    }
}
