﻿using Teknoroma.Domain.Abstracts;

namespace Teknoroma.Domain.Entities
{
	public class Employee : BaseEntity
    {
        public Guid BranchID { get; set; }
        public Guid DepartmentID { get; set; }
        public decimal? Salary { get; set; }

        public virtual List<Order> Orders { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual Department Department { get; set; }
        public virtual List<TechnicalProblem> TechnicalProblems { get; set; }
        public virtual List<Expense> Expenses { get; set; }
    }
}
