using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Employees;

namespace Teknoroma.Application.Features.Employees.Queries.GetList
{
	public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQueryRequest, List<GetAllEmployeeQueryResponse>>
	{
		private readonly IMapper _mapper;
		private readonly IEmployeeService _employeeService;

		public GetAllEmployeeQueryHandler(IMapper mapper, IEmployeeService employeeService)
        {
			_mapper = mapper;
			_employeeService = employeeService;
		}
        public async Task<List<GetAllEmployeeQueryResponse>> Handle(GetAllEmployeeQueryRequest request, CancellationToken cancellationToken)
		{
			var employees = await _employeeService.GetAllAsync();

			List<GetAllEmployeeQueryResponse> getAllEmployeeQueryResponses = _mapper.Map<List<GetAllEmployeeQueryResponse>>(employees.ToList());

			return getAllEmployeeQueryResponses;
		}
	}
}
