﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Teknoroma.Application.Features.Employees.Rules;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Employees.Command.Create
{
	public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommandRequest, Unit>
	{
		private readonly IMapper _mapper;
		private readonly IEmployeeRepository _employeeRepository;
		private readonly EmployeeBusinessRules _employeeBusinessRules;

		public CreateEmployeeCommandHandler(IMapper mapper,IEmployeeRepository employeeRepository,EmployeeBusinessRules employeeBusinessRules)
		{
			_mapper = mapper;
			_employeeRepository = employeeRepository;
			_employeeBusinessRules = employeeBusinessRules;
		}

		public async Task<Unit> Handle(CreateEmployeeCommandRequest request, CancellationToken cancellationToken)
		{
			await _employeeBusinessRules.AppUserIDCannotBeDuplicatedWhenInserted(request.ID);

			Employee employee = _mapper.Map<Employee>(request);

			await _employeeRepository.AddAsync(employee);

			return Unit.Value;
		}
	}
}
