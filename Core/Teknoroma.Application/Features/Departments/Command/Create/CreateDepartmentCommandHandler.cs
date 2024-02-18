using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Features.Departments.Rules;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Departments.Command.Create
{
	public class CreateDepartmentCommandHandler:IRequestHandler<CreateDepartmentCommandRequest, Unit>
	{
		private readonly IMapper _mapper;
		private readonly IDepartmentRepository _departmentRepository;
		private readonly DepartmentBusinessRules _departmentBusinessRules;

		public CreateDepartmentCommandHandler(IMapper mapper, IDepartmentRepository departmentRepository,DepartmentBusinessRules departmentBusinessRules)
        {
			_mapper = mapper;
			_departmentRepository = departmentRepository;
			_departmentBusinessRules = departmentBusinessRules;
		}

		public async Task<Unit> Handle(CreateDepartmentCommandRequest request, CancellationToken cancellationToken)
		{
			//BusinessRules
			await _departmentBusinessRules.DepartmentNameCannotBeDuplicatedWhenInserted(request.DepartmentName);

			Department department = _mapper.Map<Department>(request);

			await _departmentRepository.AddAsync(department);

			return Unit.Value;
		}
	}
}
