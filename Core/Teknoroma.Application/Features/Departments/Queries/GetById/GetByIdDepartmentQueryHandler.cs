using AutoMapper;
using MediatR;
using Teknoroma.Application.Repositories;

namespace Teknoroma.Application.Features.Departments.Queries.GetById
{
	public class GetByIdDepartmentQueryHandler:IRequestHandler<GetByIdDepartmentQueryRequest, GetByIdDepartmentQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IDepartmentRepository _departmentRepository;

		public GetByIdDepartmentQueryHandler(IMapper mapper, IDepartmentRepository departmentRepository)
		{
			_mapper = mapper;
			_departmentRepository = departmentRepository;
		}

		public async Task<GetByIdDepartmentQueryResponse> Handle(GetByIdDepartmentQueryRequest request, CancellationToken cancellationToken)
		{
			var department = await _departmentRepository.GetAsync(x => x.ID == request.ID);

			GetByIdDepartmentQueryResponse response = _mapper.Map<GetByIdDepartmentQueryResponse>(department);

			return response;
		}
	}
}
