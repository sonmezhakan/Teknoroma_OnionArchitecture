using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Repositories;

namespace Teknoroma.Application.Features.Departments.Queries.GetList
{
	public class GetAllDepartmentQueryHandler:IRequestHandler<GetAllDepartmentQueryRequest,List<GetAllDepartmentQueryResponse>>
	{
		private readonly IMapper _mapper;
		private readonly IDepartmentRepository _departmentRepository;

		public GetAllDepartmentQueryHandler(IMapper mapper, IDepartmentRepository departmentRepository)
		{
			_mapper = mapper;
			_departmentRepository = departmentRepository;
		}

		public async Task<List<GetAllDepartmentQueryResponse>> Handle(GetAllDepartmentQueryRequest request, CancellationToken cancellationToken)
		{
			var departments = await _departmentRepository.GetAllAsync();

			List<GetAllDepartmentQueryResponse> responses = _mapper.Map<List<GetAllDepartmentQueryResponse>>(departments);

			return responses;
		}
	}
}
