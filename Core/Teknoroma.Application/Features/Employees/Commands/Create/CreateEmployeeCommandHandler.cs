using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.Employees.Rules;
using Teknoroma.Application.Services.Employees;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Employees.Command.Create
{
	public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommandRequest, Unit>
	{
		private readonly IMapper _mapper;
		private readonly IEmployeeService _employeeService;
		private readonly EmployeeBusinessRules _employeeBusinessRules;

		public CreateEmployeeCommandHandler(IMapper mapper,IEmployeeService employeeService,EmployeeBusinessRules employeeBusinessRules)
		{
			_mapper = mapper;
			_employeeService = employeeService;
			_employeeBusinessRules = employeeBusinessRules;
		}

		public async Task<Unit> Handle(CreateEmployeeCommandRequest request, CancellationToken cancellationToken)
		{
			//BusinessRule
			await _employeeBusinessRules.AppUserIDCannotBeDuplicatedWhenInserted(request.ID);

			Employee employee = _mapper.Map<Employee>(request);

			await _employeeService.AddAsync(employee);

			return Unit.Value;
		}
	}
}
