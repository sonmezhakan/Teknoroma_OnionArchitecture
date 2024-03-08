using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Features.Departments.Contants;

namespace Teknoroma.Application.Features.Departments.Models
{
    public class CreateDepartmentViewModel
    {
        
        [Display(Name = "Departman Adı")]
        [Required(ErrorMessage = DepartmentsMessages.DepartmentNotNull)]
        public string DepartmentName { get; set; }

        [Display(Name = "Açıklama")]
        public string? Description { get; set; }
    }
}
