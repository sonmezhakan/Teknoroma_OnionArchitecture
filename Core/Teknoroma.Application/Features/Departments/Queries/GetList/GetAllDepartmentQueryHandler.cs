using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Departments;

namespace Teknoroma.Application.Features.Departments.Queries.GetList
{
	public class GetAllDepartmentQueryHandler:IRequestHandler<GetAllDepartmentQueryRequest,List<GetAllDepartmentQueryResponse>>
	{
		private readonly IMapper _mapper;
		private readonly IDepartmentService _departmentService;

		public GetAllDepartmentQueryHandler(IMapper mapper, IDepartmentService departmentService)
		{
			_mapper = mapper;
			_departmentService = departmentService;
		}

		public async Task<List<GetAllDepartmentQueryResponse>> Handle(GetAllDepartmentQueryRequest request, CancellationToken cancellationToken)
		{
			var departments = await _departmentService.GetAllAsync();

			List<GetAllDepartmentQueryResponse> responses = _mapper.Map<List<GetAllDepartmentQueryResponse>>(departments.ToList());

			return responses;
		}
	}
}
