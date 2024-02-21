using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.AppUserProfiles.Quıeries.GetById;
using Teknoroma.Application.Features.AppUsers.Queries.GetById;
using Teknoroma.Application.Features.Branches.Queries.GetById;
using Teknoroma.Application.Features.Departments.Queries.GetById;
using Teknoroma.Application.Features.Employees.Queries.GetList;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Employees.Queries.GetById
{
    public class GetByIdEmployeeQueryHandler : IRequestHandler<GetByIdEmployeeQueryRequest, GetByIdEmployeeQueryResponse>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public GetByIdEmployeeQueryHandler(IMediator mediator, IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        public async Task<GetByIdEmployeeQueryResponse> Handle(GetByIdEmployeeQueryRequest request, CancellationToken cancellationToken)
        {
            Employee employee = await _employeeRepository.GetAsync(x => x.ID == request.ID);
            GetByIdEmployeeQueryResponse getByIdEmployeeQueryResponse = _mapper.Map<GetByIdEmployeeQueryResponse>(employee);
            
            return getByIdEmployeeQueryResponse;

        }
    }
}
