using MediatR;
using Teknoroma.Application.Services.Departments;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Departments.Command.Delete
{
	public class DeleteDepartmentCommandHandler:IRequestHandler<DeleteDepartmentCommandRequest, Unit>
	{
		private readonly IDepartmentService _departmentService;

		public DeleteDepartmentCommandHandler(IDepartmentService departmentService)
        {
			_departmentService = departmentService;
		}

        public async Task<Unit> Handle(DeleteDepartmentCommandRequest request, CancellationToken cancellationToken)
		{
			Department department = await _departmentService.GetAsync(x=>x.ID == request.ID);

			await _departmentService.DeleteAsync(department);

			return Unit.Value;
		}
	}
}
