using System.ComponentModel.DataAnnotations;
using Teknoroma.Application.Features.AppUsers.Contants;

namespace Teknoroma.Application.Features.AppUsers.Models
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = AppUsersMessages.UserNameNotNull)]
		[Display(Name = AppUserColumnNames.UserName)]
		public string UserName { get; set; }

		[Required(ErrorMessage = AppUsersMessages.PasswordNotNull)]
		[Display(Name = AppUserColumnNames.Password)]
		public string Password { get; set; }
	}
}
