using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Departments.Command.Create
{
	public class CreateDepartmentCommandHandler:IRequestHandler<CreateDepartmentCommandRequest,string>
	{
		private readonly IMapper _mapper;
		private readonly IDepartmentRepository _departmentRepository;

		public CreateDepartmentCommandHandler(IMapper mapper, IDepartmentRepository departmentRepository)
        {
			_mapper = mapper;
			_departmentRepository = departmentRepository;
		}

		public async Task<string> Handle(CreateDepartmentCommandRequest request, CancellationToken cancellationToken)
		{
			Department department = _mapper.Map<Department>(request);

			await _departmentRepository.AddAsync(department);

			return "Kayıt Başarılı!";
		}
	}
}
