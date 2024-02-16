using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="User Name Boş Olamaz")]
        [Display(Name = "User Name*")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password Boş Olamaz")]
        [Display(Name = "Password*")]
        public string Password { get; set; }
    }
}
