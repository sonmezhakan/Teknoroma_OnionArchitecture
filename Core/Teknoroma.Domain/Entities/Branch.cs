using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Domain.Abstracts;

namespace Teknoroma.Domain.Entities
{
    public class Branch : BaseEntity
    {
        public string BranchName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Description { get; set; }

        public virtual List<Stock> stocks { get; set; }
        public virtual List<StockInput> StockInputs { get; set; }
    }
}
