using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.BranchProducts.Models
{
    public class BranchProductListViewModel
    {
        public string BranchName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int CriticalStock { get; set; }
    }
}
