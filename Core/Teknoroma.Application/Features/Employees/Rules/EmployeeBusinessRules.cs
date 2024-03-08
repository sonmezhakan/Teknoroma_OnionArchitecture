using Teknoroma.Application.Exceptions.Types;
using Teknoroma.Application.Features.Employees.Contants;
using Teknoroma.Application.Services.Repositories;

namespace Teknoroma.Application.Features.Employees.Rules
{
    public class EmployeeBusinessRules
	{
		private readonly IEmployeeRepository _employeeRepository;

		public EmployeeBusinessRules(IEmployeeRepository employeeRepository)
        {
			_employeeRepository = employeeRepository;
		}

		public async Task AppUserIDCannotBeDuplicatedWhenInserted(Guid appUserId)
		{
			bool result = await _employeeRepository.AnyAsync(x=>x.ID == appUserId);

			if (result)
				throw new BusinessException(EmployeesMessages.AppUserExists);
        }
	}
}
