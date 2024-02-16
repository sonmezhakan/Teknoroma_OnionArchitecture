using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Departments.Models
{
    public class DepartmentViewModel
    {
        [Required]
        [Display(Name = "ID")]
        public Guid ID { get; set; }

        [Required]
        [Display(Name = "Departman Adı")]
        public string DepartmentName { get; set; }

        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        [Display(Name = "Durum")]
        public bool? IsActive { get; set; }
    }
}
