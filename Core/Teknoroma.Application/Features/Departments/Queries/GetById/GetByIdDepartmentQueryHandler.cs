using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

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
			Department department = await _departmentRepository.GetAsync(x => x.ID == request.ID);

			GetByIdDepartmentQueryResponse response = _mapper.Map<GetByIdDepartmentQueryResponse>(request);

			return response;
		}
	}
}
