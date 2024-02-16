using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Branches.Models
{
    public class BranchListViewModel
    {

        public Guid ID { get; set; }
        public string BranchName { get; set; }
        public int? EmployeeCount { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
