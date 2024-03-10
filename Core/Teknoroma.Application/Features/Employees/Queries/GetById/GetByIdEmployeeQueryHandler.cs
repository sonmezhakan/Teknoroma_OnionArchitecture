using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Employees;

namespace Teknoroma.Application.Features.Employees.Queries.GetById
{
	public class GetByIdEmployeeQueryHandler : IRequestHandler<GetByIdEmployeeQueryRequest, GetByIdEmployeeQueryResponse>
    {
        private readonly IMapper _mapper;
		private readonly IEmployeeService _employeeService;

		public GetByIdEmployeeQueryHandler(IMapper mapper, IEmployeeService employeeService)
        {
            _mapper = mapper;
			_employeeService = employeeService;
		}

        public async Task<GetByIdEmployeeQueryResponse> Handle(GetByIdEmployeeQueryRequest request, CancellationToken cancellationToken)
        {
            var employee = await _employeeService.GetFullSearch(x => x.ID == request.ID);
            GetByIdEmployeeQueryResponse getByIdEmployeeQueryResponse = _mapper.Map<GetByIdEmployeeQueryResponse>(employee);
            
            return getByIdEmployeeQueryResponse;

        }
    }
}
