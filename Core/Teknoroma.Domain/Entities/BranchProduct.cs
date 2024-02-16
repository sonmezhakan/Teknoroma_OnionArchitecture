using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Domain.Abstracts;

namespace Teknoroma.Domain.Entities
{
    public class BranchProduct : BaseEntity
    {
        public BranchProduct()
        {
            UnitsInStock = 0;
        }
        public Guid BranchId { get; set; }
        public Guid ProductId { get; set; }
        public int UnitsInStock { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual Product Product { get; set; }
    }
}
