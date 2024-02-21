using System.ComponentModel.DataAnnotations;
using Teknoroma.Application.Features.AppUsers.Contants;

namespace Teknoroma.Application.Features.AppUsers.Models
{
    public class CreateAppUserViewModel
    {
        [Display(Name = AppUserColumnNames.UserName)]
        public string UserName { get; set; }

		[Display(Name = AppUserColumnNames.Email)]
		public string Email { get; set; }

		[Display(Name = AppUserColumnNames.Password)]
		public string Password { get; set; }

		[Display(Name = AppUserColumnNames.FirstName)]
		public string FirstName { get; set; }

		[Display(Name = AppUserColumnNames.LastName)]
		public string LastName { get; set; }

		[Display(Name = AppUserColumnNames.PhoneNumber)]
		public string PhoneNumber { get; set; }
    }
}
