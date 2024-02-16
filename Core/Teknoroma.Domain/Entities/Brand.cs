using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Domain.Abstracts;

namespace Teknoroma.Domain.Entities
{
    public class Brand : BaseEntity
    {
        public string BrandName { get; set; }
        public string? Description { get; set; }
        public string? PhoneNumber { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
