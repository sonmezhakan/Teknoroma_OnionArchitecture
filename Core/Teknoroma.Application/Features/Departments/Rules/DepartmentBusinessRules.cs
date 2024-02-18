using Teknoroma.Application.Exceptions.Types;
using Teknoroma.Application.Features.Departments.Contants;
using Teknoroma.Application.Repositories;

namespace Teknoroma.Application.Features.Departments.Rules
{
	public class DepartmentBusinessRules
	{
		private readonly IDepartmentRepository _departmentRepository;

		public DepartmentBusinessRules(IDepartmentRepository departmentRepository)
        {
			_departmentRepository = departmentRepository;
		}
		public async Task DepartmentNameCannotBeDuplicatedWhenInserted(string name)
		{
			bool result = await _departmentRepository.AnyAsync(x => x.DepartmentName == name);

			if (result)
				throw new BusinessException(DepartmentsMessages.DepartmentNameExists);
		}
		public async Task UpdateDepartmentNameCannotBeDuplicatedWhenInserted(string oldDepartmentName, string newDepartmentName)
		{
			if (oldDepartmentName != newDepartmentName)
			{
				bool result = await _departmentRepository.AnyAsync(x => x.DepartmentName == newDepartmentName);

				if (result)
					throw new BusinessException(DepartmentsMessages.DepartmentNameExists);
			}
		}
	}
}
