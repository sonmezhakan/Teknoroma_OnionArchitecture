using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Employees;

namespace Teknoroma.Application.Features.Employees.Queries.GetFullList
{
	public class GetFullListEmployeeQueryHandler : IRequestHandler<GetFullListEmployeeQueryRequest, List<GetFullListEmployeeQueryResponse>>
	{
		private readonly IMapper _mapper;
		private readonly IEmployeeService _employeeService;

		public GetFullListEmployeeQueryHandler(IMapper mapper,IEmployeeService employeeService)
        {
			_mapper = mapper;
			_employeeService = employeeService;
		}
        public async Task<List<GetFullListEmployeeQueryResponse>> Handle(GetFullListEmployeeQueryRequest request, CancellationToken cancellationToken)
		{
			var employees = await _employeeService.GetFullAll();

			List<GetFullListEmployeeQueryResponse> getFullListEmployeeQueryResponses = _mapper.Map<List<GetFullListEmployeeQueryResponse>>(employees.ToList());

			return getFullListEmployeeQueryResponses;
		}
	}
}
