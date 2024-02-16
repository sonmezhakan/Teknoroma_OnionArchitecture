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
	public class GetByIdDepartmentCommandHandler:IRequestHandler<GetByIdDepartmentCommandRequest, GetByIdDepartmentCommandResponse>
	{
		private readonly IMapper _mapper;
		private readonly IDepartmentRepository _departmentRepository;

		public GetByIdDepartmentCommandHandler(IMapper mapper, IDepartmentRepository departmentRepository)
		{
			_mapper = mapper;
			_departmentRepository = departmentRepository;
		}

		public async Task<GetByIdDepartmentCommandResponse> Handle(GetByIdDepartmentCommandRequest request, CancellationToken cancellationToken)
		{
			Department department = await _departmentRepository.GetAsync(x => x.ID == request.ID);

			GetByIdDepartmentCommandResponse response = _mapper.Map<GetByIdDepartmentCommandResponse>(request);

			return response;
		}
	}
}
