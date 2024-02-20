using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.AppUsers.Queries.GetByUserName
{
    public class GetByUserNameAppUserQueryHandler : IRequestHandler<GetByUserNameAppUserQueryRequest, GetByUserNameAppUserQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public GetByUserNameAppUserQueryHandler(IMapper mapper,UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<GetByUserNameAppUserQueryResponse> Handle(GetByUserNameAppUserQueryRequest request, CancellationToken cancellationToken)
        {
            var appUser = await _userManager.FindByNameAsync(request.UserName);

            GetByUserNameAppUserQueryResponse getByUserNameAppUserQueryResponse = _mapper.Map<GetByUserNameAppUserQueryResponse>(appUser);

            return getByUserNameAppUserQueryResponse;
        }
    }
}
