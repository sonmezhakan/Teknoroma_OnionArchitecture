using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Domain.Abstracts;

namespace Teknoroma.Domain.Entities
{
    public class Department : BaseEntity
    {
        public string DepartmentName { get; set; }
        public string? Description { get; set; }

        public virtual List<EmployeeDepartment> EmployeeDepartments { get; set; }
    }
}
