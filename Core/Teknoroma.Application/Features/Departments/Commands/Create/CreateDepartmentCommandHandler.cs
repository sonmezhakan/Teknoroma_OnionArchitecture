using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.Departments.Rules;
using Teknoroma.Application.Services.Departments;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Departments.Command.Create
{
	public class CreateDepartmentCommandHandler:IRequestHandler<CreateDepartmentCommandRequest, Unit>
	{
		private readonly IMapper _mapper;
		private readonly IDepartmentService _departmentService;
		private readonly DepartmentBusinessRules _departmentBusinessRules;

		public CreateDepartmentCommandHandler(IMapper mapper, IDepartmentService departmentService,DepartmentBusinessRules departmentBusinessRules)
        {
			_mapper = mapper;
			_departmentService = departmentService;
			_departmentBusinessRules = departmentBusinessRules;
		}

		public async Task<Unit> Handle(CreateDepartmentCommandRequest request, CancellationToken cancellationToken)
		{
			//BusinessRules
			await _departmentBusinessRules.DepartmentNameCannotBeDuplicatedWhenInserted(request.DepartmentName);

			Department department = _mapper.Map<Department>(request);

			await _departmentService.AddAsync(department);

			return Unit.Value;
		}
	}
}
