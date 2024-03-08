using System.ComponentModel.DataAnnotations;
using Teknoroma.Application.Features.AppUserRoles.Contants;

namespace Teknoroma.Application.Features.AppUserRoles.Models
{ 
    public class AppUserRoleViewModel
    {
        [Display(Name = AppUserRoleColumnNames.ID)]
        [Required(ErrorMessage = AppUserRolesMessages.IDNotNull)]
        public Guid ID { get; set; }

		[Display(Name = AppUserRoleColumnNames.Name)]
        [Required(ErrorMessage = AppUserRolesMessages.NameNotNull)]
        public string Name { get; set; }
    }
}
