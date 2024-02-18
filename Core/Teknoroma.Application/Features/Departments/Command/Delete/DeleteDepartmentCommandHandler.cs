using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Departments.Command.Delete
{
	public class DeleteDepartmentCommandHandler:IRequestHandler<DeleteDepartmentCommandRequest, Unit>
	{
		private readonly IMapper _mapper;
		private readonly IDepartmentRepository _departmentRepository;

		public DeleteDepartmentCommandHandler(IMapper mapper, IDepartmentRepository departmentRepository)
		{
			_mapper = mapper;
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
