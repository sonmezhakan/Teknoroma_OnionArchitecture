using MediatR;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Departments.Command.Delete
{
	public class DeleteDepartmentCommandHandler:IRequestHandler<DeleteDepartmentCommandRequest, Unit>
	{
		private readonly IDepartmentRepository _departmentRepository;

		public DeleteDepartmentCommandHandler(IDepartmentRepository departmentRepository)
        {
			_departmentRepository = departmentRepository;
		}

        public async Task<Unit> Handle(DeleteDepartmentCommandRequest request, CancellationToken cancellationToken)
		{
			Department department = await _departmentRepository.GetAsync(x=>x.ID == request.ID);

			await _departmentRepository.DeleteAsync(department);

			return Unit.Value;
		}
	}
}
