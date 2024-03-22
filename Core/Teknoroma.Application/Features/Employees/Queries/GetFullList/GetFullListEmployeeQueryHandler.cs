using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Repositories;

namespace Teknoroma.Application.Features.Employees.Queries.GetFullList
{
	public class GetFullListEmployeeQueryHandler : IRequestHandler<GetFullListEmployeeQueryRequest, List<GetFullListEmployeeQueryResponse>>
	{
		private readonly IMapper _mapper;
		private readonly IEmployeeRepository _employeeRepository;

		public GetFullListEmployeeQueryHandler(IMapper mapper,IEmployeeRepository employeeRepository)
        {
			_mapper = mapper;
			_employeeRepository = employeeRepository;
		}
        public async Task<List<GetFullListEmployeeQueryResponse>> Handle(GetFullListEmployeeQueryRequest request, CancellationToken cancellationToken)
		{
			var employees = await _employeeRepository.GetFullAll();

			List<GetFullListEmployeeQueryResponse> getFullListEmployeeQueryResponses = _mapper.Map<List<GetFullListEmployeeQueryResponse>>(employees.ToList());

			return getFullListEmployeeQueryResponses;
		}
	}
}
