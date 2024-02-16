using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Domain.Abstracts;

namespace Teknoroma.Domain.Entities
{
    public class EmployeeDepartment : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public Guid DepartmentId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Department Department { get; set; }
    }
}
