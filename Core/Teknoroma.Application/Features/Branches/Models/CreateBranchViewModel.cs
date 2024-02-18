using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Branches.Models
{
    public class CreateBranchViewModel
    {
        [Required]
        [Display(Name = "Branch Name*")]
        public string BranchName { get; set; }

        [Display(Name = "Address")]
        public string? Address { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Telefon Numarasını Doğru Giriniz!")]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }
    }
}
