using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Categories.Models
{
    public class CreateCategoryViewModel
    {
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Display(Name = "Statu")]
        public bool? IsActive { get; set; }
    }
}
