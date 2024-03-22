using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Repositories;

namespace Teknoroma.Application.Features.Employees.Queries.GetById
{
	public class GetByIdEmployeeQueryHandler : IRequestHandler<GetByIdEmployeeQueryRequest, GetByIdEmployeeQueryResponse>
    {
        private readonly IMapper _mapper;
		private readonly IEmployeeRepository _employeeRepository;

		public GetByIdEmployeeQueryHandler(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
			_employeeRepository = employeeRepository;
		}

        public async Task<GetByIdEmployeeQueryResponse> Handle(GetByIdEmployeeQueryRequest request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetFullSearch(x => x.ID == request.ID);
            GetByIdEmployeeQueryResponse getByIdEmployeeQueryResponse = _mapper.Map<GetByIdEmployeeQueryResponse>(employee);
            
            return getByIdEmployeeQueryResponse;

        }
    }
}
