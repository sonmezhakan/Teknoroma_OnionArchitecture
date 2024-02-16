﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Branches.Command.Update
{
	public class UpdateBranchCommandRequest:IRequest<string>
	{
		public Guid ID { get; set; }
		public string BranchName { get; set; }
		public string? Address { get; set; }
		public string? PhoneNumber { get; set; }
		public string? Description { get; set; }
		public bool? IsActive { get; set; }
	}
}
