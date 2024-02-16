using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "User Name Boş Geçilemez")]
        [Display(Name = "User Name*")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email Boş Geçilemez")]
        [Display(Name = "Email*")]
        [EmailAddress(ErrorMessage ="Email Formatı Hatalı")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Boş Geçilemez")]
        [Display(Name = "Password*")]
        public string Password { get; set; }

        [Required(ErrorMessage = "First Name Boş Geçilemez")]
        [Display(Name = "First Name*")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name Boş Geçilemez")]
        [Display(Name = "Last Name*")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone Number Boş Geçilemez")]
        [Display(Name = "Phone Number*")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address Boş Geçilemez")]
        [Display(Name = "Address*")]
        public string Address { get; set; }
    }
}
