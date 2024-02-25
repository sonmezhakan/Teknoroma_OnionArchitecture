using AutoMapper;
using MediatR;
using Teknoroma.Application.Repositories;

namespace Teknoroma.Application.Features.Employees.Queries.GetList
{
	public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQueryRequest, List<GetAllEmployeeQueryResponse>>
	{
		private readonly IMapper _mapper;
		private readonly IEmployeeRepository _employeeRepository;

		public GetAllEmployeeQueryHandler(IMapper mapper, IEmployeeRepository employeeRepository)
        {
			_mapper = mapper;
			_employeeRepository = employeeRepository;
		}
        public async Task<List<GetAllEmployeeQueryResponse>> Handle(GetAllEmployeeQueryRequest request, CancellationToken cancellationToken)
		{
			var employees = await _employeeRepository.GetAllAsync();

			List<GetAllEmployeeQueryResponse> getAllEmployeeQueryResponses = _mapper.Map<List<GetAllEmployeeQueryResponse>>(employees.ToList());

			return getAllEmployeeQueryResponses;
		}
	}
}
