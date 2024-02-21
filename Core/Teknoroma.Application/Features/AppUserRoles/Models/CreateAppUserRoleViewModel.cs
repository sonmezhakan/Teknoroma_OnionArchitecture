using System.ComponentModel.DataAnnotations;
using Teknoroma.Application.Features.AppUserRoles.Contants;

namespace Teknoroma.Application.Features.AppUserRoles.Models
{
    public class CreateAppUserRoleViewModel
    {
		[Display(Name = AppUserRoleColumnNames.Name)]
		public string Name { get; set; }
    }
}
