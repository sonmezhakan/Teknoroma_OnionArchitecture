﻿using MediatR;
using Teknoroma.Application.Pipelines.Transaction;
using Teknoroma.Domain.Enums;

namespace Teknoroma.Application.Features.TechnicalProblems.Commands.Create
{
    public class CreateTechnicalProblemCommandRequest:IRequest<Unit>, ITransactionalRequest
	{

        public string ReportedProblem { get; set; }
        public string? ProblemSolution { get; set; }
        public DateTime NotificationDate { get; set; }
        public Guid BranchId { get; set; }
        public Guid EmployeeId { get; set; }
        public TechnicalProblemStatu TechnicalProblemStatu { get; set; }
    }
}
