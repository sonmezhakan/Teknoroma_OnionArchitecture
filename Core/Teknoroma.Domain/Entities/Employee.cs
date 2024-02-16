using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Domain.Abstracts;

namespace Teknoroma.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string? ImagePath { get; set; }
        public string? Description { get; set; }

        public virtual List<EmployeeDepartment> EmployeeDepartments { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual AppUser AppUser { get; set; }
        
        //todo:Sorumlu olduğu şube entitysi oluşturulursa burada veya ayrı bir ara tablo üzerinde id tutulacak.
    }
}
