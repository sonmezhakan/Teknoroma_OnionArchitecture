﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Departments.Command.Create
{
	public class CreateDepartmentCommandRequest:IRequest<Unit>
	{
		public string DepartmentName { get; set; }
		public string? Description { get; set; }
		
	}
}
