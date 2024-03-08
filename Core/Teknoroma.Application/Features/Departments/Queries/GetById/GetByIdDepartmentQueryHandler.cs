using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Departments;

namespace Teknoroma.Application.Features.Departments.Queries.GetById
{
	public class GetByIdDepartmentQueryHandler:IRequestHandler<GetByIdDepartmentQueryRequest, GetByIdDepartmentQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IDepartmentService _departmentService;

		public GetByIdDepartmentQueryHandler(IMapper mapper, IDepartmentService departmentService)
		{
			_mapper = mapper;
			_departmentService = departmentService;
		}

		public async Task<GetByIdDepartmentQueryResponse> Handle(GetByIdDepartmentQueryRequest request, CancellationToken cancellationToken)
		{
			var department = await _departmentService.GetAsync(x => x.ID == request.ID);

			GetByIdDepartmentQueryResponse response = _mapper.Map<GetByIdDepartmentQueryResponse>(department);

			return response;
		}
	}
}
