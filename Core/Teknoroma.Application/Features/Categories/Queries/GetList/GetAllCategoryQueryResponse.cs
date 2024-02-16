using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Categories.Queries.GetList
{
    public class GetAllCategoryQueryResponse
    {
        public Guid ID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
