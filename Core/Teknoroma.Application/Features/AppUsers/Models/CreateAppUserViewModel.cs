using System.ComponentModel.DataAnnotations;
using Teknoroma.Application.Features.AppUsers.Contants;

namespace Teknoroma.Application.Features.AppUsers.Models
{
    public class CreateAppUserViewModel
    {
        [Display(Name = AppUserColumnNames.UserName)]
		[Required(ErrorMessage = AppUsersMessages.UserNameNotNull)]
		public string UserName { get; set; }

		[Display(Name = AppUserColumnNames.Email)]
		[Required(ErrorMessage = AppUsersMessages.EmailNotNull)]
		public string Email { get; set; }

		[Display(Name = AppUserColumnNames.Password)]
		[Required(ErrorMessage = AppUsersMessages.PasswordNotNull)]
		public string Password { get; set; }

		[Display(Name = AppUserColumnNames.FirstName)]
		[Required(ErrorMessage = AppUsersMessages.FirstNameNotNull)]
		public string FirstName { get; set; }

		[Display(Name = AppUserColumnNames.LastName)]
		[Required(ErrorMessage = AppUsersMessages.LastNameNotNull)]
		public string LastName { get; set; }

		[Display(Name = AppUserColumnNames.PhoneNumber)]
		[Required(ErrorMessage = AppUsersMessages.PhoneNumberNotNull)]
		public string PhoneNumber { get; set; }

		[Display(Name = AppUserColumnNames.Roles)]
        public List<string>? AppUserRoles { get; set; }
    }
}
